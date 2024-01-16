import { defineStore } from 'pinia'
import { Tournament } from '~/models/tournaments/Tournament'
import { TournamentFilter } from '~/models/tournaments/TournamentFilter'
import { Game } from '~/models/games/Game'
import { Platform } from '~/models/tournaments/Platform'
import { Region } from '~/models/tournaments/Region'

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
      const game = new Game(6, 'War Thunder', '', 4, 'https://warthunder.com/i/opengraph-wt.jpg')
      const platform = new Platform(1, 'PC')
      const region = new Region(1, 'Europe')

      const utcDate = new Date(Date.UTC(2024, 0, 20, 0, 0, 0))

      this.tournaments = [
        new Tournament(1, 'Super Tournament', 2, game, platform, region, utcDate),
        new Tournament(2, 'Other Tournament', 4, game, platform, region, utcDate),
        new Tournament(3, 'Amazing Tournament?', 2, game, platform, region, utcDate)
      ].map(tournament => tournament.toJson() as Tournament)

      return Promise.resolve(this.tournaments)
    }

  },
  getters: {
    tournamentById: (state) => (id: number): Tournament => {
      return state.tournaments.find(game => game.id === id) as Tournament
    }
  }
})

if (import.meta.hot) {
  import.meta.hot.accept(acceptHMRUpdate(useTournamentsStore, import.meta.hot))
}
