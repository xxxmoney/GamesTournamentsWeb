import type { Prize } from '~/models/tournaments/Prize'
import type { TournamentPlayer } from '~/models/tournaments/TournamentPlayer'
import type { Match } from '~/models/tournaments/Match'
import type { Stream } from '~/models/tournaments/Stream'
import { ConvertableToJson } from '~/models/ConvertableToJson'
import constants from '~/constants'

class TournamentEdit extends ConvertableToJson {
  id: number | null
  name: string | null
  teamSize: number | null
  gameId: number | null
  platformId: number | null
  regionIds: number[]
  startDate: Date | null
  endDate: Date | null
  info: string | null
  rules: string | null
  prizes: Prize[]
  players: TournamentPlayer[]
  match: Match | null
  streams: Stream[]
  minimumPlayers: number | null
  maximumPlayers: number | null
  currencyId: number
  anyoneCanJoin: boolean
  adminIds: number[]

  constructor () {
    super()

    this.id = null
    this.name = null
    this.teamSize = null
    this.gameId = null
    this.platformId = null
    this.regionIds = []
    this.startDate = null
    this.endDate = null
    this.info = null
    this.rules = null
    this.prizes = []
    this.players = []
    this.match = null
    this.streams = []
    this.minimumPlayers = null
    this.maximumPlayers = null
    this.currencyId = constants.defaultCurrencyId
    this.anyoneCanJoin = false
    this.adminIds = []
  }
}

export { TournamentEdit }
