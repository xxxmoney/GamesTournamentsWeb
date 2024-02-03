import { defineStore } from 'pinia'
import type { AccountInfo } from '~/models/user/AccountInfo'
import type { HistoryItem } from '~/models/user/HistoryItem'
import { AccountService } from '~/apiServices/AccountService'

export const useAccountStore = defineStore({
  id: 'account-store',
  state: () => ({
    info: null as AccountInfo | null,
    history: [] as HistoryItem[],
    passwordChangeModalActive: false,
    historyModalActive: false
  }),
  actions: {
    initialize (): Promise<void> {
      return Promise.resolve()
    },

    async getAccountInfo (accountId: number): Promise<AccountInfo> {
      this.info = await AccountService.getAccountInfo(accountId)
      return this.info
    },

    async getHistory (accountId: number): Promise<HistoryItem[]> {
      this.history = await AccountService.getHistory(accountId)
      return this.history
    },

    openPasswordChangeModal (): void {
      this.passwordChangeModalActive = true
    },
    closePasswordChangeModal (): void {
      this.passwordChangeModalActive = false
    },

    openHistoryModal (): void {
      this.historyModalActive = true
    },
    closeHistoryModal (): void {
      this.historyModalActive = false
    }

  },
  getters: {}
})

if (import.meta.hot) {
  import.meta.hot.accept(acceptHMRUpdate(useAccountStore, import.meta.hot))
}
