import type { TournamentPlayer } from '~/models/tournaments/TournamentPlayer'

interface Team {
    id: number
    name: string
    players: TournamentPlayer[]
}

export type { Team }
