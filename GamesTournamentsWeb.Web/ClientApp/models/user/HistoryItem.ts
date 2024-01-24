import { ConvertableToJson } from '~/models/ConvertableToJson'

class HistoryItem extends ConvertableToJson {
  public accountId: number
  public gameId: number
  public gameName: string
  public place: number
  public tournamentId: number

  constructor (accountId: number, gameId: number, gameName: string, place: number, tournamentId: number) {
    super()

    this.accountId = accountId
    this.gameId = gameId
    this.gameName = gameName
    this.place = place
    this.tournamentId = tournamentId
  }
}

export { HistoryItem }
