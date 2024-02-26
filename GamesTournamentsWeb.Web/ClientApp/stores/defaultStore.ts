import { defineStore } from 'pinia'

export const useDefaultStore = defineStore({
  id: 'default-store',
  state: () => ({}),
  actions: {},
  getters: {}
})

if (import.meta.hot) {
  import.meta.hot.accept(acceptHMRUpdate(useDefaultStore, import.meta.hot))
}
