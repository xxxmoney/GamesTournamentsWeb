export const useIsTournamentDetailStarted = () => {
  const tournamentsStore = useTournamentsStore()

  return computed(() => tournamentsStore.isTournamentDetailStarted)
}
