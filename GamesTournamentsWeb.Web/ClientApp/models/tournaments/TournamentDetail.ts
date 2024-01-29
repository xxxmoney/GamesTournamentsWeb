import { ConvertableToJson } from '~/models/ConvertableToJson'
import type { Game } from '~/models/games/Game'
import type { Platform } from '~/models/tournaments/Platform'
import type { Region } from '~/models/tournaments/Region'
import type { Prize } from '~/models/tournaments/Prize'
import type { TournamentPlayer } from '~/models/tournaments/TournamentPlayer'
import type { Match } from '~/models/tournaments/Match'

// class TournamentDetail extends ConvertableToJson {
//   public id: number
//   public name: string
//   public teamSize: number
//   public game: Game
//   public platform: Platform
//   public region: Region
//   public startDate: Date
//   public info: string
//   public rules: string
//   public prizes: Prize[]
//   public players: TournamentPlayer[]
//   public matches: Match[]
//   public streams: string[]
//
//   constructor (
//     id: number,
//     name: string,
//     teamSize: number,
//     game: Game,
//     platform: Platform,
//     region: Region,
//     startDate: Date,
//     info: string,
//     rules: string,
//     prizes: Prize[],
//     players: TournamentPlayer[],
//     matches: Match[],
//     streams: string[]
//   ) {
//     super()
//
//     this.id = id
//     this.name = name
//     this.teamSize = teamSize
//     this.game = game
//     this.platform = platform
//     this.region = region
//     this.startDate = startDate
//     this.info = info
//     this.rules = rules
//     this.prizes = prizes
//     this.players = players
//     this.matches = matches
//     this.streams = streams
//   }
// }

interface TournamentDetail {
    id: number
    name: string
    teamSize: number
    game: Game
    platform: Platform
    region: Region
    startDate: Date
    info: string
    rules: string
    prizes: Prize[]
    players: TournamentPlayer[]
    matches: Match[]
    streams: string[]
}

export type { TournamentDetail }
