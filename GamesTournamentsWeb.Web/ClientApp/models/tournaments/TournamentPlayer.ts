import type { Account } from '~/models/user/Account'

interface TournamentPlayer {
    account: Account
    gameUsername: string
    statusId: number
}

export type { TournamentPlayer }
