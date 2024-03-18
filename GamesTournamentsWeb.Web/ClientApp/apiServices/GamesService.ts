import type { Game } from '~/models/games/Game'
import type { Genre } from '~/models/games/Genre'
import type { GameFilter } from '~/models/games/GameFilter'
import type { GameOverview } from '~/models/games/GameOverview'
import type { PagedResult } from '~/models/PagedResult'

export const GamesSerivce = {
  async getGames (filter: GameFilter): Promise<PagedResult<Game>> {
    const api = useApi()
    const result = await api.post<PagedResult<Game>>('games', filter)
    return result.data
  },

  async getGameOverviews (): Promise<GameOverview[]> {
    const api = useApi()
    const result = await api.get<GameOverview[]>('games/overviews')
    return result.data
  },

  async getGenres (): Promise<Genre[]> {
    const api = useApi()
    const result = await api.get<Genre[]>('genres')
    return result.data
  }

}
