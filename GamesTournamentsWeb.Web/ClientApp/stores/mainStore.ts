import { defineStore } from 'pinia'

export const useMainStore = defineStore({
  id: 'main-store',
  state: () => ({
    isLoggedIn: false,
    mobileMenuActive: false
  }),
  actions: {
    initialize () {

    },

    openMobileMenu () {
      this.mobileMenuActive = true
    },
    closeMobileMenu () {
      this.mobileMenuActive = false
    }
  },
  getters: {}
})

if (import.meta.hot) {
  import.meta.hot.accept(acceptHMRUpdate(useMainStore, import.meta.hot))
}
