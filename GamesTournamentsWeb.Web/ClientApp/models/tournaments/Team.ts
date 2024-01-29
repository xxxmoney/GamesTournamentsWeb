import { ConvertableToJson } from '~/models/ConvertableToJson'
import { TournamentPlayer } from '~/models/tournaments/TournamentPlayer'

// class Team extends ConvertableToJson {
//   public name: string
//   public players: TournamentPlayer[]
//
//   constructor (name: string, players: TournamentPlayer[]) {
//     super()
//
//     this.name = name
//     this.players = players
//   }
// }

interface Team {
    name: string
    players: TournamentPlayer[]
}

export type { Team }
