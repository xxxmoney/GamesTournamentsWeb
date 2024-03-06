import { defineStore } from 'pinia'
import type { LayoutItem } from '~/models/dashboard/LayoutItem'
import { DashboardService } from '~/apiServices/DashboardService'

export const useDashboardStore = defineStore({
  id: 'dashboard-store',
  state: () => ({
    layout: [] as LayoutItem[]
  }),
  actions: {
    async initialize (): Promise<void> {
      return Promise.resolve()
    },
    async getLayout (): Promise<LayoutItem[]> {
      this.layout = await DashboardService.getLayout()
      return this.layout
    }
  },
  getters: {}
})

if (import.meta.hot) {
  import.meta.hot.accept(acceptHMRUpdate(useDefaultStore, import.meta.hot))
}
