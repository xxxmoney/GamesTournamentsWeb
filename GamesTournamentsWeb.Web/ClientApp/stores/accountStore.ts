import { defineStore } from 'pinia'
import type { AccountInfo } from '~/models/user/AccountInfo'
import type { HistoryItem } from '~/models/user/HistoryItem'

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
      this.info = { id: accountId, matchesPlayed: 10, winRateRatio: 0.5 }
      return Promise.resolve(this.info)
    },

    getHistory (accountId: number): Promise<HistoryItem[]> {
      this.history = [
        { accountId, gameId: 2, gameName: 'War Thunder' }
      ]

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
