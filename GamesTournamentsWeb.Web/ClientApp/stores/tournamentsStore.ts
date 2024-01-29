import { defineStore } from 'pinia'
import type { Tournament } from '~/models/tournaments/Tournament'
import { TournamentFilter } from '~/models/tournaments/TournamentFilter'
import type { Platform } from '~/models/tournaments/Platform'
import type { Region } from '~/models/tournaments/Region'
import type { TournamentDetail } from '~/models/tournaments/TournamentDetail'

export const useTournamentsStore = defineStore({
  id: 'tournaments-store',
  state: () => ({
    tournaments: [] as Tournament[],
    tournamentDetail: null as TournamentDetail | null,
    teamSizes: [] as number[],
    regions: [] as Region[],
    platforms: [] as Platform[],
    filter: new TournamentFilter().toJson() as TournamentFilter
  }),
  actions: {
    async initialize (): Promise<void> {
      await Promise.all([
        this.getTournaments(),
        this.getTeamSizes(),
        this.getRegions(),
        this.getPlatforms()
      ])
    },

    getTournaments (): Promise<Tournament[]> {
      const game = {
        id: 6,
        name: 'War Thunder',
        description: '',
        genreId: 4,
        imageUrl: 'https://warthunder.com/i/opengraph-wt.jpg'
      }
      const platform = { id: 1, name: 'PC', code: 'pc' }
      const region = { id: 1, name: 'Europe', code: 'europe' }

      const utcDate = new Date(Date.UTC(2024, 0, 20, 0, 0, 0))

      this.tournaments = [
        { id: 1, name: 'Super Tournament', teamSize: 2, game, platform, region, startDate: utcDate },
        { id: 2, name: 'Other Tournament', teamSize: 4, game, platform, region, startDate: utcDate },
        { id: 3, name: 'Amazing Tournament?', teamSize: 2, game, platform, region, startDate: utcDate }
      ]

      return Promise.resolve(this.tournaments)
    },

    getTeamSizes (): Promise<number[]> {
      this.teamSizes = Array.from(Array(256).keys()).map(i => i + 1)
      return Promise.resolve(this.teamSizes)
    },

    getRegions (): Promise<Region[]> {
      this.regions = [
        { id: 1, name: 'Europe', code: 'europe' },
        { id: 2, name: 'North America', code: 'north_america' },
        { id: 3, name: 'Asia', code: 'asia' }
      ]

      return Promise.resolve(this.regions)
    },

    getPlatforms (): Promise<Platform[]> {
      this.platforms = [
        { id: 1, name: 'PC', code: 'pc' },
        { id: 2, name: 'Xbox', code: 'xbox' },
        { id: 3, name: 'Playstation', code: 'playstation' }
      ]

      return Promise.resolve(this.platforms)
    }

    // getTournamentDetail(tournamentId: number): Promise<TournamentDetail> {
    //
    // }

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
