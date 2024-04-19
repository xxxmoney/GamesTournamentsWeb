import type { Account } from '~/models/user/Account'

interface TournamentPlayer {
    id: number
    account: Account
    accountId: Number
    tournamentId: number,
    gameUsername: string | null
    statusId: number,
    expectedWinnerId: number | null
}

export type { TournamentPlayer }
