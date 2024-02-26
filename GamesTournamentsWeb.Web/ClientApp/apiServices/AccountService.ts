import type { AccountInfo } from '~/models/user/AccountInfo'
import type { HistoryItem } from '~/models/user/HistoryItem'
import type { Account } from '~/models/user/Account'

export const AccountService = {
  getAccountInfo (accountId: number): Promise<AccountInfo> {
    const result = { id: accountId, matchesPlayed: 10, winRateRatio: 0.5 }

    return Promise.resolve(result)
  },

  getHistory (accountId: number): Promise<HistoryItem[]> {
    const result = [
      { accountId, gameId: 2, gameName: 'War Thunder', tournamentId: 1 }
    ]

    return Promise.resolve(result)
  },

  getAccounts (): Promise<Account[]> {
    const result = [
      { id: 1, username: 'PlayerElOne', email: 'email', password: 'password', role: 'user' },
      { id: 2, username: 'PlayerZoTwo', email: 'email', password: 'password', role: 'user' },
      { id: 3, username: 'Uwuwu', email: 'email', password: 'password', role: 'user' },
      { id: 4, username: 'AtomicNek', email: 'email', password: 'password', role: 'user' }
    ]

    return Promise.resolve(result)
  }
}
