import { ConvertableToJson } from '~/models/ConvertableToJson'

// class AccountInfo extends ConvertableToJson {
//   public id: number
//   public matchesPlayed: number
//   public winRateRatio: number
//
//   constructor (id: number, matchesPlayed: number, winRateRatio: number) {
//     super()
//
//     this.id = id
//     this.matchesPlayed = matchesPlayed
//     this.winRateRatio = winRateRatio
//   }
// }

interface AccountInfo {
    id: number
    matchesPlayed: number
    winRateRatio: number
}

export type { AccountInfo }
