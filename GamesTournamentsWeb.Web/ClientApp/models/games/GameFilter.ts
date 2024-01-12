import { ConvertableToJson } from '~/models/ConvertableToJson'

class GameFilter extends ConvertableToJson {
  public name: string | null
  public genreId: number | null
  public withMyTournaments: boolean

  constructor () {
    super()

    this.name = null
    this.genreId = null
    this.withMyTournaments = false
  }
}

export { GameFilter }
