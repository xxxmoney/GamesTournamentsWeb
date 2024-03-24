import type { TournamentOverview } from '~/models/tournaments/TournamentOverview'
import type { TournamentFilter } from '~/models/tournaments/TournamentFilter'
import type { Region } from '~/models/tournaments/Region'
import type { Platform } from '~/models/tournaments/Platform'
import type { Tournament } from '~/models/tournaments/Tournament'
import type { Currency } from '~/models/tournaments/Currency'
import type { PagedResult } from '~/models/PagedResult'
import type { TournamentEdit } from '~/models/tournaments/TournamentEdit'

export const TournamentsService = {
  async getTournamentOverviews (filter: TournamentFilter): Promise<PagedResult<TournamentOverview>> {
    const api = useApi()
    const result = await api.post<PagedResult<TournamentOverview>>('tournaments/overviews', filter)
    return result.data
  },

  getTeamSizes (): Promise<number[]> {
    const result = Array.from(Array(256).keys()).map(i => i + 1)
    return Promise.resolve(result)
  },

  async getRegions (): Promise<Region[]> {
    const api = useApi()
    const result = await api.get<Region[]>('regions')
    return result.data
  },

  async getPlatforms (): Promise<Platform[]> {
    const api = useApi()
    const result = await api.get<Platform[]>('platforms')
    return result.data
  },

  async getCurrencies (): Promise<Currency[]> {
    const api = useApi()
    const result = await api.get<Currency[]>('currencies')
    return result.data
  },

  async getTournamentById (tournamentId: number): Promise<Tournament> {
    const api = useApi()
    const result = await api.get<Tournament>(`tournaments/${tournamentId}`)
    return result.data
  },

  async upsertTournament (tournament: TournamentEdit): Promise<Tournament> {
    const api = useApi()
    const result = await api.post('tournaments/upsert', tournament)
    return result.data
  }
}
