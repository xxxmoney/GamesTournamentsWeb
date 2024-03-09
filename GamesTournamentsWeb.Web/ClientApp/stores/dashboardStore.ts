import { defineStore } from 'pinia'
import type { LayoutDetail } from '~/models/dashboard/LayoutDetail'
import { DashboardService } from '~/apiServices/DashboardService'
import type { LayoutItem } from '~/models/dashboard/LayoutItem'
import type { LayoutUpsert } from '~/models/dashboard/LayoutUpsert'
import type { Layout } from '~/models/dashboard/Layout'
import { DashboardMapper } from '~/mappers/dashboardMapper'

export const useDashboardStore = defineStore({
  id: 'dashboard-store',
  state: () => ({
    layouts: [] as LayoutDetail[],
    selectedLayoutId: null as Number | null,
    layoutUpsert: null as LayoutUpsert | null,
    upsertLayoutModalActive: false
  }),
  actions: {
    initialize (): Promise<void> {
      return Promise.resolve()
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
    updateLayoutItems (items: LayoutItem[]): Promise<LayoutItem[]> {
      return DashboardService.updateLayoutItems(items)
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
    }
  },
  getters: {
    selectedLayout (): LayoutDetail | null {
      return this.layouts.find(layout => layout.id === this.selectedLayoutId) ?? null
    }
  }
})

if (import.meta.hot) {
  import.meta.hot.accept(acceptHMRUpdate(useDefaultStore, import.meta.hot))
}
