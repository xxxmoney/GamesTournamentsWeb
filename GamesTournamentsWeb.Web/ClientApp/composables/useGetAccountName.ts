export const useGetAccountName = () => {
  const accounts = useAccounts()

  const getAccountName = (accountId: number) => {
    const account = accounts.value.find(item => item.id === accountId)
    return account?.username ?? ''
  }

  return { getAccountName }
}
