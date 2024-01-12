import { ConvertableToJson } from '~/models/ConvertableToJson.ts'

class Game extends ConvertableToJson {
  public id: number
  public name: string
  public description: string
  public genre: number
  public imageUrl: string

  constructor (id: number, name: string, description: string, genre: string, imageUrl: string) {
    super()

    this.id = id
    this.name = name
    this.description = description
    this.genre = genre
    this.imageUrl = imageUrl
  }
}

export { Game }
