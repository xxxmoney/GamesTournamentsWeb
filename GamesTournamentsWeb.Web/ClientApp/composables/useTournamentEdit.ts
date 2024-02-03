export const useTournamentEdit = () => {
  const tournamentsStore = useTournamentsStore()

  return computed(() => tournamentsStore.tournamentEdit!)
}
