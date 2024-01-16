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
    async initialize (): Promise<void> {
      await Promise.all([
        this.getGames(),
        this.getGenres()
      ])
    },

    getGames (): Promise<Game[]> {
      this.games = [
        new Game(1, 'Leaage Of Legends', '', 1, 'https://cdn1.epicgames.com/offer/24b9b5e323bc40eea252a10cdd3b2f10/EGS_LeagueofLegends_RiotGames_S1_2560x1440-872a966297484acd0efe49f34edd5aed'),
        new Game(2, 'Counter Strike', '', 2, 'https://media.steampowered.com/apps/csgo/blog/images/fb_image.png?v=6'),
        new Game(3, 'Valorant', '', 2, 'https://cdn.vox-cdn.com/thumbor/eNOhiVdnvnyYEv_9kIw1IABEyZI=/0x0:3011x1447/1400x933/filters:focal(1123x329:1603x809):no_upscale()/cdn.vox-cdn.com/uploads/chorus_image/image/66954486/VALORANT_Jett_Red_crop.0.jpg'),
        new Game(4, 'Dota 2', '', 1, 'https://business-portal-bucket.s3.amazonaws.com/media/images/41e172c318357d632f53b92d8cb38661_lar.original.format-png.png'),
        new Game(5, 'Fifa 21', '', 3, 'https://cdn.aktivcommunication.cz/images/products/screens/7434/2.jpg'),
        new Game(6, 'War Thunder', '', 4, 'https://warthunder.com/i/opengraph-wt.jpg')
      ].map(game => game.toJson() as Game)

      return Promise.resolve(this.games)
    },

    getGenres (): Promise<Genre[]> {
      this.genres = [
        new Genre(1, 'MOBA'),
        new Genre(2, 'FPS'),
        new Genre(3, 'Sports'),
        new Genre(4, 'Simulation')
      ].map(genre => genre.toJson() as Genre)

      return Promise.resolve(this.genres)
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
