export default defineNuxtPlugin({
  async setup (_) {
    const stores = useAllStores()
    await Promise.all(Object.values(stores).map(s => s.initialize()))
  },
  hooks: {
    'vue:setup' () {
      const mainStore = useMainStore()

      const applyLocale = useApplyLocale()
      applyLocale(mainStore.locale)
    }
  }
})
