import { ConvertableToJson } from '~/models/ConvertableToJson'

// class Prize extends ConvertableToJson {
//   place: number
//   amount: number
//   currency: string
//
//   constructor (place: number, amount: number, currency: string) {
//     super()
//
//     this.place = place
//     this.amount = amount
//     this.currency = currency
//   }
// }

interface Prize {
    place: number
    amount: number
    currency: string
}

export type { Prize }
