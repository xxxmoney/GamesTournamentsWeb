import type { Account } from '~/models/user/Account'

interface TournamentPlayer {
    account: Account
    gameUsername: string
    status: string
}

export type { TournamentPlayer }
