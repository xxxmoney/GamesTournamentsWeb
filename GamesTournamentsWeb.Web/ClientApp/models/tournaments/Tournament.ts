import { ConvertableToJson } from '~/models/ConvertableToJson'

class Tournament extends ConvertableToJson {
  public id: number
  public name: string
  public teamSize: number
  public gameId: number

  constructor (id: number, name: string, teamSize: number, gameId: number) {
    super()

    this.id = id
    this.name = name
    this.teamSize = teamSize
    this.gameId = gameId
  }
}

export { Tournament }
