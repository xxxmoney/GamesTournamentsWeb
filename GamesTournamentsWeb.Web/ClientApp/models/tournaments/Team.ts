import type { TournamentPlayer } from '~/models/tournaments/TournamentPlayer'

interface Team {
    name: string
    players: TournamentPlayer[]
}

export type { Team }
