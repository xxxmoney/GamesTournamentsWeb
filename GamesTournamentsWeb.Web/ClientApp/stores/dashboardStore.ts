import { defineStore } from 'pinia'
import type { Layout } from '~/models/dashboard/Layout'
import { DashboardService } from '~/apiServices/DashboardService'
import type { LayoutItem } from '~/models/dashboard/LayoutItem'
import type { LayoutUpsert } from '~/models/dashboard/LayoutUpsert'
import type { LayoutOverview } from '~/models/dashboard/LayoutOverview'
import { DashboardMapper } from '~/mappers/DashboardMapper'
import type { Module } from '~/models/dashboard/Module'
import constants from '~/constants'
import { component } from '~/enums/dashboard/component'

export const useDashboardStore = defineStore({
  id: 'dashboard-store',
  state: () => ({
    loading: true,
    layouts: [] as Layout[],
    selectedLayoutId: null as number | null,
    layoutUpsert: null as LayoutUpsert | null,
    selectedLayoutItemId: null as number | null,
    upsertLayoutModalActive: false,
    selectModuleModalActive: false
  }),
  actions: {
    initialize (): Promise<void> {
      this.loading = false

      return Promise.resolve()
    },

    async getLayouts (): Promise<Layout[]> {
      try {
        this.loading = true

        this.layouts = await DashboardService.getLayouts()
        return this.layouts
      } finally {
        this.loading = false
      }
    },
    async upsertLayout (layoutUpsert: LayoutUpsert): Promise<LayoutOverview> {
      try {
        this.loading = true

        const upsertedLayout = await DashboardService.upsertLayout(layoutUpsert)

        const index = this.layouts.findIndex(layout => layout.id === upsertedLayout.id)
        if (index === -1) {
          this.layouts.push(DashboardMapper.mapLayoutToLayoutDetail(upsertedLayout))
          this.selectedLayoutId = upsertedLayout.id
        } else {
          this.layouts[index].name = upsertedLayout.name
        }

        return upsertedLayout
      } finally {
        this.loading = false
      }
    },
    async upsertSelectedLayoutItems (items: LayoutItem[]): Promise<LayoutItem[]> {
      if (!this.selectedLayout) {
        throw new Error('No layout selected')
      }

      try {
        this.loading = true

        const upsertedItems = await DashboardService.upsertLayoutItems(items)
        this.selectedLayout.items = upsertedItems
        return upsertedItems
      } finally {
        this.loading = false
      }
    },

    addItemToLayout (moduleId: number) {
      if (!this.selectedLayout) {
        throw new Error('No layout selected')
      }

      // TODO: check if this works properly, id null should be inserted
      const lastIndex = this.selectedLayout.items.length
      const item = {
        layoutId: this.selectedLayout.id,
        moduleId,
        id: null,
        i: lastIndex,
        x: 0,
        y: 0,
        w: constants.defaultLayoutItemWidth,
        h: constants.defaultLayoutItemHeight
      }
      this.selectedLayout.items.push(item)
    },
    updateOrAddSelectedLayoutItem (moduleId: number) {
      if (!this.selectedLayout) {
        throw new Error('No layout selected')
      }

      const item = this.selectedLayoutItem
      if (item) {
        item.moduleId = moduleId
      } else {
        this.addItemToLayout(moduleId)
      }
    },
    removeItemFromLayout (itemId: number) {
      if (!this.selectedLayout) {
        throw new Error('No layout selected')
      }

      const index = this.selectedLayout.items.findIndex(item => item.id === itemId)
      if (index !== -1) {
        this.selectedLayout.items.splice(index, 1)
      }
    },

    setDefaultLayoutUpsert (): void {
      this.layoutUpsert = {
        id: null,
        name: ''
      }
    },
    clearLayoutUpsert (): void {
      this.layoutUpsert = null
    },
    setCurrentLayoutAsUpsert (): void {
      if (!this.selectedLayout) {
        throw new Error('No layout selected')
      }

      this.layoutUpsert = DashboardMapper.mapLayoutDetailToLayoutUpsert(this.selectedLayout!)
    },

    openUpsertLayoutModal (): void {
      this.upsertLayoutModalActive = true
    },
    closeUpsertLayoutModal (): void {
      this.clearLayoutUpsert()
      this.upsertLayoutModalActive = false
    },

    openSelectModuleModal (): void {
      this.selectModuleModalActive = true
    },
    closeSelectModuleModal (): void {
      this.selectedLayoutItemId = null
      this.selectModuleModalActive = false
    }
  },
  getters: {
    selectedLayout (): Layout | null {
      return this.layouts.find(layout => layout.id === this.selectedLayoutId) ?? null
    },
    selectedLayoutItem (): LayoutItem | null {
      return this.selectedLayoutItemId ? this.selectedLayout?.items.find(item => item.id === this.selectedLayoutItemId) ?? null : null
    },
    modules (): Module[] {
      return Object.entries(component).map(([key, value]) => ({ id: value, name: key }))
    }
  }
})

if (import.meta.hot) {
  import.meta.hot.accept(acceptHMRUpdate(useDefaultStore, import.meta.hot))
}
