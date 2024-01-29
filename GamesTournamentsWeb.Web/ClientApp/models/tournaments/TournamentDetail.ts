import type { Game } from '~/models/games/Game'
import type { Platform } from '~/models/tournaments/Platform'
import type { Region } from '~/models/tournaments/Region'
import type { Prize } from '~/models/tournaments/Prize'
import type { TournamentPlayer } from '~/models/tournaments/TournamentPlayer'
import type { Match } from '~/models/tournaments/Match'

interface TournamentDetail {
    id: number
    name: string
    teamSize: number
    game: Game
    platform: Platform
    region: Region
    startDate: Date
    info: string
    rules: string
    prizes: Prize[]
    players: TournamentPlayer[]
    matches: Match[]
    streams: string[]
}

export type { TournamentDetail }
