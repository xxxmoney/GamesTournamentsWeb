import { ConvertableToJson } from '~/models/ConvertableToJson'
import type { Team } from '~/models/tournaments/Team'

// class Match extends ConvertableToJson {
//   public firstTeam: Team
//   public secondTeam: Team
//   public winner: Team
//
//   constructor (firstTeam: Team, secondTeam: Team, winner: Team) {
//     super()
//
//     this.firstTeam = firstTeam
//     this.secondTeam = secondTeam
//     this.winner = winner
//   }
// }

interface Match {
    firstTeam: Team
    secondTeam: Team
    winner: Team
}

export type { Match }
