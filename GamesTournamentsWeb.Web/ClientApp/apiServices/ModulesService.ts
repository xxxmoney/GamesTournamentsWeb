import type { ModuleWinLossRatioData } from '~/models/dashboard/ModuleWinLossRatioData'
import type { ModuleWinLossRatioRequest } from '~/models/dashboard/ModuleWinLossRatioRequest'

export const ModulesService = {
  async getModuleLossWinRatioData (request: ModuleWinLossRatioRequest): Promise<ModuleWinLossRatioData> {
    const api = useApi()
    const result = await api.post<ModuleWinLossRatioData>('modules/win-loss-ratio', request)
    return result.data
  }
}
