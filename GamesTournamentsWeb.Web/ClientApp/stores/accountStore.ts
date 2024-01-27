import { defineStore } from 'pinia'
import { AccountInfo } from '~/models/user/AccountInfo'
import { HistoryItem } from '~/models/user/HistoryItem'

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

    getAccountInfo (accountId: number): Promise<AccountInfo> {
      const info = new AccountInfo(accountId, 10, 0.5)
      this.info = info.toJson() as AccountInfo
      return Promise.resolve(info)
    },

    getHistory (accountId: number): Promise<HistoryItem[]> {
      this.history = [
        new HistoryItem(accountId, 1, 'War Thunder', 2, 69)
      ].map(historyItem => historyItem.toJson() as HistoryItem)

      return Promise.resolve(this.history)
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
