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
    },

    getTournamentDetailById (tournamentId: number): Promise<TournamentDetail> {
      const players = [
        {
          account: {
            id: 1,
            name: 'ElPlayero',
            email: '',
            role: {
              id: 1,
              name: 'User'
            },
            createdAt: new Date(Date.UTC(2024, 0, 20, 0, 0, 0)),
            imageUrl: null
          },
          gameUsername: 'PlayerElOne',
          statusId: 1
        },
        {
          account: {
            id: 2,
            name: 'ZoPlayero',
            email: '',
            role: {
              id: 1,
              name: 'User'
            },
            createdAt: new Date(Date.UTC(2024, 0, 20, 0, 0, 0)),
            imageUrl: null
          },
          gameUsername: 'PlayerZoTwo',
          statusId: 1
        }
      ]

      const firstTeam = {
        name: 'Team One',
        players: [players[0]]
      }
      const secondTeam = {
        name: 'Team Two',
        players: [players[1]]
      }

      this.tournamentDetail = {
        id: tournamentId,
        name: 'Super Tournament',
        teamSize: 2,
        game: {
          id: 6,
          name: 'War Thunder',
          description: '',
          genreId: 4,
          imageUrl: 'https://warthunder.com/i/opengraph-wt.jpg'
        },
        platform: {
          id: 1,
          name: 'PC',
          code: 'pc'
        },
        region: {
          id: 1,
          name: 'Europe',
          code: 'europe'
        },
        startDate: new Date(Date.UTC(2024, 0, 20, 0, 0, 0)),
        endDate: new Date(Date.UTC(2024, 0, 20, 0, 0, 0)),
        info: 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Etiam quis quam. Sed vel lectus. ',
        rules: 'Fusce consectetuer risus a nunc. Suspendisse nisl. Nulla turpis magna, cursus sit amet, suscipit a, interdum id, felis. Aliquam erat volutpat. \n' +
                    'Nulla pulvinar eleifend sem. In rutrum. Aliquam erat volutpat. \n' +
                    'Duis bibendum, lectus ut viverra rhoncus, dolor nunc faucibus libero, eget facilisis enim ipsum id lacus. \n' +
                    'Mauris metus. Maecenas fermentum, sem in pharetra pellentesque, velit turpis volutpat ante, in pharetra metus odio a lectus. \n' +
                    'Nullam feugiat, turpis at pulvinar vulputate, erat libero tristique tellus, nec bibendum odio risus sit amet ante. Sed elit dui, pellentesque a, faucibus vel, interdum nec, diam.',
        settings: 'Sed elit dui, pellentesque a, faucibus vel, interdum nec, diam. Sed vel lectus. Donec odio tempus molestie, porttitor ut, iaculis quis, sem. Integer lacinia. Fusce suscipit libero eget elit. \n' +
                    'Aenean id metus id velit ullamcorper pulvinar. \n' +
                    'Donec iaculis gravida nulla. \n' +
                    'Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nulla quis diam. Pellentesque habitant morbi tristique senectus et.',
        prizes: [
          { place: 1, amount: 1000, currency: 'USD', currencySymbol: '$' },
          { place: 2, amount: 500, currency: 'USD', currencySymbol: '$' },
          { place: 3, amount: 250, currency: 'USD', currencySymbol: '$' },
          { place: 4, amount: 100, currency: 'USD', currencySymbol: '$' },
          { place: 5, amount: 50, currency: 'USD', currencySymbol: '$' }
        ],
        players,
        matches: [
          {
            firstTeam,
            secondTeam,
            winner: null
          }
        ],
        streams: []
      }

      return Promise.resolve(this.tournamentDetail)
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
