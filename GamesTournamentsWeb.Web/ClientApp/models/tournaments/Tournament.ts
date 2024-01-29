import { ConvertableToJson } from '~/models/ConvertableToJson'
import type { Game } from '~/models/games/Game'
import type { Platform } from '~/models/tournaments/Platform'
import type { Region } from '~/models/tournaments/Region'

// class Tournament extends ConvertableToJson {
//   public id: number
//   public name: string
//   public teamSize: number
//   public game: Game
//   public platform: Platform
//   public region: Region
//   public startDate: Date
//
//   constructor (id: number, name: string, teamSize: number, game: Game, platform: Platform, region: Region, startDate: Date) {
//     super()
//
//     this.id = id
//     this.name = name
//     this.teamSize = teamSize
//     this.game = game
//     this.platform = platform
//     this.region = region
//     this.startDate = startDate
//   }
//
//   toJson (): Object {
//     const result = super.toJson() as Tournament
//     result.game = this.game
//     result.platform = this.platform.toJson() as Platform
//     result.region = this.region.toJson() as Region
//     return result
//   }
// }

interface Tournament {
    id: number
    name: string
    teamSize: number
    game: Game
    platform: Platform
    region: Region
    startDate: Date
}

export type { Tournament }
