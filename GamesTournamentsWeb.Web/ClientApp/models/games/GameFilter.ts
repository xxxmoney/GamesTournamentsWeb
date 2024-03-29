import { ConvertableToJson } from '~/models/ConvertableToJson'

class GameFilter extends ConvertableToJson {
  public name: string | null
  public genreIds: number[]
  public page: number

  constructor () {
    super()

    this.name = null
    this.genreIds = []
    this.page = 1
  }
}

export { GameFilter }
