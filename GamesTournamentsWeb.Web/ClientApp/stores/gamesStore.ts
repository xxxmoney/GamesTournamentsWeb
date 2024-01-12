import { defineStore } from 'pinia'
import { GameFilter } from '~/models/games/GameFilter'
import { Game } from '~/models/games/Game'
import { Genre } from '~/models/games/Genre'

export const useGamesStore = defineStore({
  id: 'games-store',
  state: () => ({
    games: [] as Game[],
    filter: new GameFilter().toJson() as GameFilter,
    genres: [] as Genre[]
  }),
  actions: {
    async initialize (): Promise {
      await Promise.all([
        this.getGames(),
        this.getGenres()
      ])
    },

    getGames (): Promise<Game[]> {
      this.games = [
        new Game(1, 'Leage Of Legends', '', 1, ''),
        new Game(2, 'Counter Strike', '', 2, ''),
        new Game(3, 'Valorant', '', 2, ''),
        new Game(4, 'Dota 2', '', 1, ''),
        new Game(5, 'Fifa 21', '', 3, ''),
        new Game(6, 'War Thunder', '', 4, '')
      ].map(game => game.toJson())

      return Promise.resolve(this.games)
    },

    getGenres (): Promise<Genre[]> {
      this.genres = [
        new Genre(1, 'MOBA'),
        new Genre(2, 'FPS'),
        new Genre(3, 'Sports'),
        new Genre(4, 'Simulation')
      ].map(genre => genre.toJson())

      return Promise.resolve(this.genres)
    }
  },
  getters: {}
})
