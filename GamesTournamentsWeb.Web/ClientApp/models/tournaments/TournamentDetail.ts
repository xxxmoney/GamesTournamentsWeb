import type { Game } from '~/models/games/Game'
import type { Platform } from '~/models/tournaments/Platform'
import type { Region } from '~/models/tournaments/Region'
import type { Prize } from '~/models/tournaments/Prize'
import type { TournamentPlayer } from '~/models/tournaments/TournamentPlayer'
import type { Match } from '~/models/tournaments/Match'
import type { Stream } from '~/models/tournaments/Stream'

interface TournamentDetail {
    id: number
    name: string
    teamSize: number
    game: Game
    platform: Platform
    regions: Region[]
    startDate: Date
    endDate: Date
    info: string
    rules: string,
    settings: string
    prizes: Prize[]
    players: TournamentPlayer[]
    matches: Match[]
    streams: Stream[]
}

export type { TournamentDetail }
