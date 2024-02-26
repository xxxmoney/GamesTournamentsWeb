export const useAccounts = () => {
  const accountStore = useAccountStore()
  return computed(() => accountStore.accounts)
}
