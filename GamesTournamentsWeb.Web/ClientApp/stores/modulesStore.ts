import { defineStore } from 'pinia'
import type { ModuleWinLossRatioData } from '~/models/dashboard/ModuleWinLossRatioData'
import { ModulesService } from '~/apiServices/ModulesService'
import type { ModuleWinLossRatioRequest } from '~/models/dashboard/ModuleWinLossRatioRequest'

export const useModulesStore = defineStore({
  id: 'modules-store',
  state: () => ({
    loading: true,
    modules: {
      winLossData: new Map<number, ModuleWinLossRatioData>()
    }
  }),
  actions: {
    initialize (): Promise<void> {
      this.loading = false
      return Promise.resolve()
    },

    async getModuleWinLossData (moduleId: number, request: ModuleWinLossRatioRequest): Promise<ModuleWinLossRatioData> {
      try {
        this.loading = true

        const data = await ModulesService.getModuleLossWinRatioData(request)
        this.modules.winLossData.set(moduleId, data)

        return data
      } finally {
        this.loading = false
      }
    }
  },
  getters: {}
})

if (import.meta.hot) {
  import.meta.hot.accept(acceptHMRUpdate(useDefaultStore, import.meta.hot))
}
