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
      const game = new Game(6, 'War Thunder', '', 4, 'https://warthunder.com/i/opengraph-wt.jpg')
      const platform = new Platform(1, 'PC', 'pc')
      const region = new Region(1, 'Europe', 'europe')

      const utcDate = new Date(Date.UTC(2024, 0, 20, 0, 0, 0))

      this.tournaments = [
        new Tournament(1, 'Super Tournament', 2, game, platform, region, utcDate),
        new Tournament(2, 'Other Tournament', 4, game, platform, region, utcDate),
        new Tournament(3, 'Amazing Tournament?', 2, game, platform, region, utcDate)
      ].map(tournament => tournament.toJson() as Tournament)

      return Promise.resolve(this.tournaments)
    },

    getTeamSizes (): Promise<number[]> {
      this.teamSizes = Array.from(Array(256).keys()).map(i => i + 1)
      return Promise.resolve(this.teamSizes)
    },

    getRegions (): Promise<Region[]> {
      this.regions = [
        new Region(1, 'Europe', 'europe'),
        new Region(2, 'North America', 'north_america'),
        new Region(3, 'Asia', 'asia')
      ].map(region => region.toJson() as Region)

      return Promise.resolve(this.regions)
    },

    getPlatforms (): Promise<Platform[]> {
      this.platforms = [
        new Platform(1, 'PC', 'pc'),
        new Platform(2, 'Xbox', 'xbox'),
        new Platform(3, 'Playstation', 'playstation')
      ].map(platform => platform.toJson() as Platform)

      return Promise.resolve(this.platforms)
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
