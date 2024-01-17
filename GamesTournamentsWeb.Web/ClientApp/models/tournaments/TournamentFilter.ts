import { ConvertableToJson } from '~/models/ConvertableToJson'

class TournamentFilter extends ConvertableToJson {
  public name: string | null
  public gameId: number | null
  public teamSizes: number[]
  public regionIds: number[]
  public platformIds: number[]
  public genreIds: number[]
  public withMyTournaments: boolean

  constructor () {
    super()

    this.name = null
    this.gameId = null
    this.teamSizes = []
    this.regionIds = []
    this.platformIds = []
    this.genreIds = []
    this.withMyTournaments = false
  }
}

export { TournamentFilter }
