export const useIsTournamentDetailFinished = () => {
  const tournamentsStore = useTournamentsStore()

  return computed(() => tournamentsStore.isTournamentDetailFinished)
}
