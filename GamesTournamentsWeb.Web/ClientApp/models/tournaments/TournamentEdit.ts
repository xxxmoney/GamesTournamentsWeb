import type { Prize } from '~/models/tournaments/Prize'
import type { TournamentPlayer } from '~/models/tournaments/TournamentPlayer'
import type { Match } from '~/models/tournaments/Match'
import type { Stream } from '~/models/tournaments/Stream'
import { ConvertableToJson } from '~/models/ConvertableToJson'
import constants from '~/constants'

class TournamentEdit extends ConvertableToJson {
  id: number | null
  name: string
  teamSize: number | null
  gameId: number | null
  platformId: number | null
  regionIds: number[]
  startDate: Date | null
  endDate: Date | null
  info: string
  rules: string
  settings: string
  prizes: Prize[]
  players: TournamentPlayer[]
  matches: Match[]
  streams: Stream[]
  minimumPlayers: number | null
  maximumPlayers: number | null
  currencyId: number

  constructor () {
    super()

    this.id = null
    this.name = ''
    this.teamSize = null
    this.gameId = null
    this.platformId = null
    this.regionIds = []
    this.startDate = null
    this.endDate = null
    this.info = ''
    this.rules = ''
    this.settings = ''
    this.prizes = []
    this.players = []
    this.matches = []
    this.streams = []
    this.minimumPlayers = null
    this.maximumPlayers = null
    this.currencyId = constants.defaultCurrencyId
  }
}

export { TournamentEdit }
