import { defineStore } from 'pinia'
import type { LayoutDetail } from '~/models/dashboard/LayoutDetail'
import { DashboardService } from '~/apiServices/DashboardService'
import type { LayoutItem } from '~/models/dashboard/LayoutItem'
import type { LayoutUpsert } from '~/models/dashboard/LayoutUpsert'
import type { Layout } from '~/models/dashboard/Layout'
import { DashboardMapper } from '~/mappers/dashboardMapper'
import type { Module } from '~/models/dashboard/Module'
import constants from '~/constants'

export const useDashboardStore = defineStore({
  id: 'dashboard-store',
  state: () => ({
    modules: [] as Module[],
    layouts: [] as LayoutDetail[],
    selectedLayoutId: null as number | null,
    layoutUpsert: null as LayoutUpsert | null,
    selectedLayoutItemId: null as number | null,
    upsertLayoutModalActive: false,
    selectModuleModalActive: false
  }),
  actions: {
    async initialize (): Promise<void> {
      await Promise.all([
        this.getModules()
      ])
    },

    async getModules (): Promise<Module[]> {
      this.modules = await DashboardService.getModules()
      return this.modules
    },

    async getLayouts (userId: number): Promise<LayoutDetail[]> {
      this.layouts = await DashboardService.getLayouts(userId)
      return this.layouts
    },
    async upsertLayout (layoutUpsert: LayoutUpsert): Promise<Layout> {
      const upsertedLayout = await DashboardService.upsertLayout(layoutUpsert)

      const index = this.layouts.findIndex(layout => layout.id === upsertedLayout.id)
      if (index === -1) {
        this.layouts.push(DashboardMapper.mapLayoutToLayoutDetail(upsertedLayout))
        this.selectedLayoutId = upsertedLayout.id
      } else {
        this.layouts[index].name = upsertedLayout.name
      }

      return upsertedLayout
    },
    async upsertSelectedLayoutItems (items: LayoutItem[]): Promise<LayoutItem[]> {
      if (!this.selectedLayout) {
        throw new Error('No layout selected')
      }

      const upsertedItems = await DashboardService.upsertLayoutItems(items)
      this.selectedLayout.items = upsertedItems
      return upsertedItems
    },

    addItemToLayout (moduleId: number) {
      if (!this.selectedLayout) {
        throw new Error('No layout selected')
      }

      const item = {
        layoutId: this.selectedLayout.id,
        moduleId,
        i: null,
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
    selectedLayout (): LayoutDetail | null {
      return this.layouts.find(layout => layout.id === this.selectedLayoutId) ?? null
    },
    selectedLayoutItem (): LayoutItem | null {
      return this.selectedLayoutItemId ? this.selectedLayout?.items.find(item => item.i === this.selectedLayoutItemId) ?? null : null
    },
    moduleById: (state) => (id: number): Module | null => {
      return state.modules.find(module => module.id === id) ?? null
    }
  }
})

if (import.meta.hot) {
  import.meta.hot.accept(acceptHMRUpdate(useDefaultStore, import.meta.hot))
}
