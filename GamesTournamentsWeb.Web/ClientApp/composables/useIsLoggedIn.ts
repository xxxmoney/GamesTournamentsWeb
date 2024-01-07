// TODO

export const useIsLoggedIn = () => {
  const store = useMainStore()
  return computed(() => store.isLoggedIn)
}
