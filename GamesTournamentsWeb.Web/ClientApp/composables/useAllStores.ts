const useAllStores = () => {
  const accountStore = useAccountStore()
  const dashboardStore = useDashboardStore()
  const gamesStore = useGamesStore()
  const mainStore = useMainStore()
  const tournamentsStore = useTournamentsStore()
  const modulesStore = useModulesStore()

  return {
    accountStore,
    dashboardStore,
    gamesStore,
    mainStore,
    tournamentsStore,
    modulesStore
  }
}

export { useAllStores }
