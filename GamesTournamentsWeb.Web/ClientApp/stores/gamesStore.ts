import { defineStore } from 'pinia'
import { GameFilter } from '~/models/games/GameFilter'
import type { Game } from '~/models/games/Game'
import type { Genre } from '~/models/games/Genre'
import { GamesSerivce } from '~/apiServices/GamesService'
import type { GameOverview } from '~/models/games/GameOverview'
import type { PagedResult } from '~/models/PagedResult'

export const useGamesStore = defineStore({
  id: 'games-store',
  state: () => ({
    loading: true,
    pagedGames: null as PagedResult<Game> | null,
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

      this.loading = false
    },

    async getGames (): Promise<Game[]> {
      try {
        this.loading = true

        this.pagedGames = await GamesSerivce.getGames(this.filter)
        return this.games
      } finally {
        this.loading = false
      }
    },

    async getGameOverviews (): Promise<GameOverview[]> {
      try {
        this.loading = true

        this.gameOverviews = await GamesSerivce.getGameOverviews()
        return this.gameOverviews
      } finally {
        this.loading = false
      }
    },

    async getGenres (): Promise<Genre[]> {
      try {
        this.loading = true

        this.genres = await GamesSerivce.getGenres()
        return this.genres
      } finally {
        this.loading = false
      }
    }
  },
  getters: {
    games: (state) => {
      return state.pagedGames?.results ?? []
    },
    gameById: (state) => (id: number): Game => {
      return (state.pagedGames?.results ?? []).find(game => game.id === id) as Game
    }
  }
})

if (import.meta.hot) {
  import.meta.hot.accept(acceptHMRUpdate(useGamesStore, import.meta.hot))
}
