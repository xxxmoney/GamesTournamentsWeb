import { ConvertableToJson } from '~/models/ConvertableToJson'
import { Game } from '~/models/games/Game'
import { Platform } from '~/models/tournaments/Platform'
import { Region } from '~/models/tournaments/Region'

class Tournament extends ConvertableToJson {
  public id: number
  public name: string
  public teamSize: number
  public game: Game
  public platform: Platform
  public region: Region
  public startDate: Date

  constructor (id: number, name: string, teamSize: number, game: Game, platform: Platform, region: Region, startDate: Date) {
    super()

    this.id = id
    this.name = name
    this.teamSize = teamSize
    this.game = game
    this.platform = platform
    this.region = region
    this.startDate = startDate
  }

  toJson (): Object {
    const result = super.toJson() as Tournament
    result.game = this.game.toJson() as Game
    result.platform = this.platform.toJson() as Platform
    result.region = this.region.toJson() as Region
    return result
  }
}

export { Tournament }
