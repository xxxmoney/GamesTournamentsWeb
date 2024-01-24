import { defineStore } from 'pinia'
import { AccountInfo } from '~/models/user/AccountInfo'

export const useAccountStore = defineStore({
  id: 'account-store',
  state: () => ({
    info: null as AccountInfo | null,
    passwordChangeModalActive: false,
    historyModalActive: false
  }),
  actions: {

    getAccountInfo (id: number): Promise<AccountInfo> {
      const info = new AccountInfo(id, 10, 0.5)
      this.info = info.toJson() as AccountInfo
      return Promise.resolve(info)
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
