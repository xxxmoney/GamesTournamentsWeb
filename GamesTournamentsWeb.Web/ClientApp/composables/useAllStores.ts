const useAllStores = () => {
  const accountStore = useAccountStore()
  const dashboardStore = useDashboardStore()
  const gamesStore = useGamesStore()
  const mainStore = useMainStore()
  const tournamentsStore = useTournamentsStore()

  return {
    accountStore,
    dashboardStore,
    gamesStore,
    mainStore,
    tournamentsStore
  }
}

export { useAllStores }
