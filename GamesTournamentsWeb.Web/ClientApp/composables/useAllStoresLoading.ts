const useAllStoresLoading = () => {
  const stores = useAllStores()

  return computed(() => Object.values(stores).some(s => s.loading))
}

export { useAllStoresLoading }
