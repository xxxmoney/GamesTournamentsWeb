import { ConvertableToJson } from '~/models/ConvertableToJson'

class Genre extends ConvertableToJson {
  public id: number
  public name: string

  constructor (id: number, name: string) {
    super()

    this.id = id
    this.name = name
  }
}

export { Genre }
