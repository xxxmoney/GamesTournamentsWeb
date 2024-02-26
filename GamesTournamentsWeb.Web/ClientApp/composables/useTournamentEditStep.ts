export const useTournamentEditStep = () => {
  const tournamentsStore = useTournamentsStore()

  return computed({
    get: () => tournamentsStore.tournamentEditStep,
    set: (value: number) => {
      tournamentsStore.tournamentEditStep = value
    }
  })
}
