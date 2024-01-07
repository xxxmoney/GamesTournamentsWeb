import { defineStore } from 'pinia'

export const useMainStore = defineStore({
  id: 'main-store',
  state: () => ({
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
