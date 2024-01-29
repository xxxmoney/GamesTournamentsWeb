import type { Team } from '~/models/tournaments/Team'

interface Match {
    firstTeam: Team
    secondTeam: Team
    winner: Team
}

export type { Match }
