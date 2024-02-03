import type { Team } from '~/models/tournaments/Team'

interface Match {
    id: number
    nextMatchId: number | null
    tournamentId: number
    firstTeam: Team | null
    secondTeam: Team | null
    winner: Team | null
}

export type { Match }
