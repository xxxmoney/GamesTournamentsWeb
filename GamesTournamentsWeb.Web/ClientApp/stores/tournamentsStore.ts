import { defineStore } from 'pinia'
import { Tournament } from '~/models/tournaments/Tournament'
import { TournamentFilter } from '~/models/tournaments/TournamentFilter'

export const useTournamentsStore = defineStore({
  id: 'tournaments-store',
  state: () => ({
    tournaments: [] as Tournament[],
    filter: new TournamentFilter().toJson() as TournamentFilter
  }),
  actions: {
    async initialize (): Promise<void> {
      await Promise.all([
        this.getTournaments()
      ])
    },

    getTournaments (): Promise<Tournament[]> {
      this.tournaments = [
        new Tournament(1, 'Super Tournament', 1, 1)
      ].map(tournament => tournament.toJson())

      return Promise.resolve(this.tournaments)
    }

  },
  getters: {}
})

if (import.meta.hot) {
  import.meta.hot.accept(acceptHMRUpdate(useTournamentsStore, import.meta.hot))
}
