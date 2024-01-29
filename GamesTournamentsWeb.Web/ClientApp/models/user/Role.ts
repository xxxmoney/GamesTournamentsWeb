import { ConvertableToJson } from '~/models/ConvertableToJson'

// class Role extends ConvertableToJson {
//   id: number
//   name: string
//
//   constructor (id: number, name: string) {
//     super()
//
//     this.id = id
//     this.name = name
//   }
// }

interface Role {
    id: number
    name: string
}

export type { Role }
