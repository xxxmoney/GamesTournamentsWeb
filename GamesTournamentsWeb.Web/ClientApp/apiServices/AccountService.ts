import type { AccountInfo } from '~/models/user/AccountInfo'
import type { HistoryItem } from '~/models/user/HistoryItem'
import type { Account } from '~/models/user/Account'
import { useApi } from '~/composables/useApi'

export const AccountService = {
  async getAccountInfo (accountId: number): Promise<AccountInfo> {
    const api = useApi()
    const result = await api.get<AccountInfo>(`accounts/${accountId}/info`)
    return result.data
  },

  async getHistory (accountId: number): Promise<HistoryItem[]> {
    const api = useApi()
    const result = await api.get<HistoryItem[]>(`accounts/${accountId}/history`)
    return result.data
  },

  async getAccounts (): Promise<Account[]> {
    const api = useApi()
    const result = await api.get<Account[]>('accounts/all')
    return result.data
  }
}
