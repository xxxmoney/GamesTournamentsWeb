import type { Prize } from '~/models/tournaments/Prize'
import type { TournamentPlayer } from '~/models/tournaments/TournamentPlayer'
import type { Match } from '~/models/tournaments/Match'
import type { Stream } from '~/models/tournaments/Stream'
import { ConvertableToJson } from '~/models/ConvertableToJson'

class TournamentEdit extends ConvertableToJson {
  id: number | null
  name: string
  teamSize: number | null
  gameId: number | null
  platformId: number | null
  regionId: number | null
  startDate: Date | null
  endDate: Date | null
  info: string
  rules: string
  settings: string
  prizes: Prize[]
  players: TournamentPlayer[]
  matches: Match[]
  streams: Stream[]

  constructor () {
    super()

    this.id = null
    this.name = ''
    this.teamSize = null
    this.gameId = null
    this.platformId = null
    this.regionId = null
    this.startDate = null
    this.endDate = null
    this.info = ''
    this.rules = ''
    this.settings = ''
    this.prizes = []
    this.players = []
    this.matches = []
    this.streams = []
  }
}

export { TournamentEdit }
