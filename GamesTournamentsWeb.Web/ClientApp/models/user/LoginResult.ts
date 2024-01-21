import { Account } from '~/models/user/Account'

interface LoginResult {
    token: string;
    account: Account;
}

export type { LoginResult }
