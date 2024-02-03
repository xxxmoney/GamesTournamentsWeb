import { defineStore } from 'pinia'
import { GameFilter } from '~/models/games/GameFilter'
import type { Game } from '~/models/games/Game'
import type { Genre } from '~/models/games/Genre'
import { GamesSerivce } from '~/apiServices/GamesService'
import type { GameOverview } from '~/models/games/GameOverview'

export const useGamesStore = defineStore({
  id: 'games-store',
  state: () => ({
    games: [] as Game[],
    filter: new GameFilter().toJson() as GameFilter,
    genres: [] as Genre[],
    gameOverviews: [] as GameOverview[]
  }),
  actions: {
    async initialize (): Promise<void> {
      await Promise.all([
        this.getGames(),
        this.getGameOverviews(),
        this.getGenres()
      ])
    },

    async getGames (): Promise<Game[]> {
      this.games = await GamesSerivce.getGames(this.filter)
      return this.games
    },

    async getGameOverviews (): Promise<GameOverview[]> {
      this.gameOverviews = await GamesSerivce.getGameOverviews()
      return this.gameOverviews
    },

    async getGenres (): Promise<Genre[]> {
      this.genres = await GamesSerivce.getGenres()
      return this.genres
    }
  },
  getters: {
    gameById: (state) => (id: number): Game => {
      return state.games.find(game => game.id === id) as Game
    }
  }
})

if (import.meta.hot) {
  import.meta.hot.accept(acceptHMRUpdate(useGamesStore, import.meta.hot))
}
