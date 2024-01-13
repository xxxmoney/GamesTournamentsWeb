import { ConvertableToJson } from '~/models/ConvertableToJson'

class Game extends ConvertableToJson {
  public id: number
  public name: string
  public description: string
  public genreId: number
  public imageUrl: string

  constructor (id: number, name: string, description: string, genreId: number, imageUrl: string) {
    super()

    this.id = id
    this.name = name
    this.description = description
    this.genreId = genreId
    this.imageUrl = imageUrl
  }
}

export { Game }
