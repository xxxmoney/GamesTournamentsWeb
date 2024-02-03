import type { Game } from '~/models/games/Game'
import type { Genre } from '~/models/games/Genre'
import type { GameFilter } from '~/models/games/GameFilter'

export const GamesSerivce = {
  getGames (filter: GameFilter): Promise<Game[]> {
    const games = [
      {
        id: 1,
        name: 'Leaage Of Legends',
        description: '',
        genreId: 1,
        imageUrl: 'https://cdn1.epicgames.com/offer/24b9b5e323bc40eea252a10cdd3b2f10/EGS_LeagueofLegends_RiotGames_S1_2560x1440-872a966297484acd0efe49f34edd5aed'
      },
      {
        id: 2,
        name: 'Counter Strike',
        description: '',
        genreId: 2,
        imageUrl: 'https://media.steampowered.com/apps/csgo/blog/images/fb_image.png?v=6'
      },
      {
        id: 3,
        name: 'Valorant',
        description: '',
        genreId: 2,
        imageUrl: 'https://cdn.vox-cdn.com/thumbor/eNOhiVdnvnyYEv_9kIw1IABEyZI=/0x0:3011x1447/1400x933/filters:focal(1123x329:1603x809):no_upscale()/cdn.vox-cdn.com/uploads/chorus_image/image/66954486/VALORANT_Jett_Red_crop.0.jpg'
      },
      {
        id: 4,
        name: 'Dota 2',
        description: '',
        genreId: 1,
        imageUrl: 'https://business-portal-bucket.s3.amazonaws.com/media/images/41e172c318357d632f53b92d8cb38661_lar.original.format-png.png'
      },
      {
        id: 5,
        name: 'Fifa 21',
        description: '',
        genreId: 3,
        imageUrl: 'https://cdn.aktivcommunication.cz/images/products/screens/7434/2.jpg'
      },
      {
        id: 6,
        name: 'War Thunder',
        description: '',
        genreId: 4,
        imageUrl: 'https://warthunder.com/i/opengraph-wt.jpg'
      }
    ]

    return Promise.resolve(games)
  },

  getGenres (): Promise<Genre[]> {
    const genres = [
      { id: 1, name: 'MOBA' },
      { id: 2, name: 'FPS' },
      { id: 3, name: 'Sports' },
      { id: 4, name: 'Simulation' }
    ]

    return Promise.resolve(genres)
  }

}
