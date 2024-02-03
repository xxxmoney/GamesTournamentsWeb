import type { AccountInfo } from '~/models/user/AccountInfo'
import type { HistoryItem } from '~/models/user/HistoryItem'

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
  }
}
