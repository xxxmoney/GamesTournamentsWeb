import type { Game } from '~/models/games/Game'
import type { Platform } from '~/models/tournaments/Platform'
import type { Region } from '~/models/tournaments/Region'

interface TournamentOverview {
    id: number
    name: string
    teamSize: number
    game: Game
    platform: Platform
    regions: Region[]
    startDate: Date
    endDate: Date
}

export type { TournamentOverview }
