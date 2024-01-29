import { ConvertableToJson } from '~/models/ConvertableToJson'
import { Account } from '~/models/user/Account'

class TournamentPlayer extends ConvertableToJson {
  public account: Account
  public gameUsername: string
  public statusId: number

  constructor (account: Account, gameUsername: string, statusId: number) {
    super()

    this.account = account
    this.gameUsername = gameUsername
    this.statusId = statusId
  }
}

export { TournamentPlayer }
