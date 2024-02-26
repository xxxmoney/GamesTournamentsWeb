export const useTournamentDetail = () => {
  const tournamentsStore = useTournamentsStore()

  return computed(() => tournamentsStore.tournamentDetail!)
}
