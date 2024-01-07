export const useMobileMenuActive = () => {
  const store = useMainStore()
  return computed({
    get: () => store.mobileMenuActive,
    set: (value) => {
      if (value) {
        store.openMobileMenu()
      } else {
        store.closeMobileMenu()
      }
    }
  })
}
