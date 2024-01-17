import { ConvertableToJson } from '~/models/ConvertableToJson'

class Region extends ConvertableToJson {
  public id: number
  public name: string
  public code: string

  constructor (id: number, name: string, code: string) {
    super()

    this.id = id
    this.name = name
    this.code = code
  }
}

export { Region }
