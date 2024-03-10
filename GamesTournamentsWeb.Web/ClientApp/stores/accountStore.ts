import { defineStore } from 'pinia'
import type { AccountInfo } from '~/models/user/AccountInfo'
import type { HistoryItem } from '~/models/user/HistoryItem'
import { AccountService } from '~/apiServices/AccountService'
import type { Account } from '~/models/user/Account'

export const useAccountStore = defineStore({
  id: 'account-store',
  state: () => ({
    loading: false,
    accounts: [] as Account[],
    info: null as AccountInfo | null,
    history: [] as HistoryItem[],
    passwordChangeModalActive: false,
    historyModalActive: false
  }),
  actions: {
    async initialize (): Promise<void> {
      await Promise.all([
        this.getAccounts()
      ])
    },

    async getAccountInfo (accountId: number): Promise<AccountInfo> {
      try {
        this.loading = true

        this.info = await AccountService.getAccountInfo(accountId)
        return this.info
      } finally {
        this.loading = false
      }
    },

    async getHistory (accountId: number): Promise<HistoryItem[]> {
      try {
        this.loading = true

        this.history = await AccountService.getHistory(accountId)
        return this.history
      } finally {
        this.loading = false
      }
    },

    async getAccounts (): Promise<Account[]> {
      try {
        this.loading = true

        this.accounts = await AccountService.getAccounts()
        return this.accounts
      } finally {
        this.loading = false
      }
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
