import type { Tournament } from '~/models/tournaments/Tournament'
import type { TournamentFilter } from '~/models/tournaments/TournamentFilter'
import type { Region } from '~/models/tournaments/Region'
import type { Platform } from '~/models/tournaments/Platform'
import type { TournamentDetail } from '~/models/tournaments/TournamentDetail'
import { gamePlayerStatus } from '~/enums/tournaments/gamePlayerStatus'

export const TournamentsService = {
  getTournaments (filter: TournamentFilter): Promise<Tournament[]> {
    const game = {
      id: 6,
      name: 'War Thunder',
      description: '',
      genreId: 4,
      imageUrl: 'https://warthunder.com/i/opengraph-wt.jpg'
    }
    const platform = { id: 1, name: 'PC', code: 'pc' }
    const regions = [{ id: 1, name: 'Europe', code: 'europe' }]

    const utcDate = new Date(Date.UTC(2024, 0, 20, 0, 0, 0))

    const tournaments = [
      { id: 1, name: 'Super Tournament', teamSize: 2, game, platform, regions, startDate: utcDate },
      { id: 2, name: 'Other Tournament', teamSize: 4, game, platform, regions, startDate: utcDate },
      { id: 3, name: 'Amazing Tournament?', teamSize: 2, game, platform, regions, startDate: utcDate }
    ]

    return Promise.resolve(tournaments)
  },

  getTeamSizes (): Promise<number[]> {
    const result = Array.from(Array(256).keys()).map(i => i + 1)
    return Promise.resolve(result)
  },

  getRegions (): Promise<Region[]> {
    const result = [
      { id: 1, name: 'Europe', code: 'europe' },
      { id: 2, name: 'North America', code: 'north_america' },
      { id: 3, name: 'Asia', code: 'asia' }
    ]

    return Promise.resolve(result)
  },

  getPlatforms (): Promise<Platform[]> {
    const result = [
      { id: 1, name: 'PC', code: 'pc' },
      { id: 2, name: 'Xbox', code: 'xbox' },
      { id: 3, name: 'Playstation', code: 'playstation' }
    ]

    return Promise.resolve(result)
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
        status: gamePlayerStatus.accepted
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
        status: gamePlayerStatus.accepted
      },
      {
        account: {
          id: 3,
          name: 'UwuZoPlayero',
          email: '',
          role: {
            id: 1,
            name: 'User'
          },
          createdAt: new Date(Date.UTC(2024, 0, 20, 0, 0, 0)),
          imageUrl: null
        },
        gameUsername: 'Uwuwu',
        status: gamePlayerStatus.pending
      },
      {
        account: {
          id: 4,
          name: 'AraAraPlayero',
          email: '',
          role: {
            id: 1,
            name: 'User'
          },
          createdAt: new Date(Date.UTC(2024, 0, 20, 0, 0, 0)),
          imageUrl: null
        },
        gameUsername: 'AtomicNek',
        status: gamePlayerStatus.pending
      }
    ]

    const teams = players.map((player, index) => {
      return {
        id: index + 1,
        name: player.gameUsername,
        players: [player]
      }
    })

    const matches = [
      { id: 1, nextMatchId: 3, tournamentId, firstTeam: teams[0], secondTeam: teams[1], winner: null },
      { id: 2, nextMatchId: 3, tournamentId, firstTeam: teams[2], secondTeam: teams[3], winner: null },
      { id: 3, nextMatchId: null, tournamentId, firstTeam: null, secondTeam: null, winner: null }
    ]

    const tournamentDetail = {
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
      regions: [{
        id: 1,
        name: 'Europe',
        code: 'europe'
      }],
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
      matches,
      streams: [
        { name: 'Rick The First', url: 'https://www.youtube.com/embed/dQw4w9WgXcQ?si=tPb-oERlfwu0gk3Y' },
        { name: 'Rick The Second', url: 'https://www.youtube.com/embed/qWNQUvIk954?si=Nf03OVIlvbZAokk1' }
      ]
    }

    return Promise.resolve(tournamentDetail)
  }
}
