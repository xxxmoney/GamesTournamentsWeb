import { defineStore } from 'pinia'
import { AccountInfo } from '~/models/user/AccountInfo'

export const useAccountStore = defineStore({
  id: 'account-store',
  state: () => ({
    info: null as AccountInfo | null
  }),
  actions: {

    getAccountInfo (id: number): Promise<AccountInfo> {
      const info = new AccountInfo(id, 10, 0.5)
      this.info = info.toJson() as AccountInfo
      return Promise.resolve(info)
    }

  },
  getters: {}
})

if (import.meta.hot) {
  import.meta.hot.accept(acceptHMRUpdate(useAccountStore, import.meta.hot))
}
