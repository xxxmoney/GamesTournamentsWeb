import type { AccountInfo } from '~/models/user/AccountInfo'
import type { HistoryItem } from '~/models/user/HistoryItem'
import type { Account } from '~/models/user/Account'
import type { TournamentPlayer } from '~/models/tournaments/TournamentPlayer'

export const AccountService = {
  async getAccountInfo (): Promise<AccountInfo> {
    const api = useApi()
    const result = await api.get<AccountInfo>('accounts/mine/info')
    return result.data
  },

  async getHistory (): Promise<HistoryItem[]> {
    const api = useApi()
    const result = await api.get<HistoryItem[]>('accounts/mine/history')
    return result.data
  },

  async getAccounts (): Promise<Account[]> {
    const api = useApi()
    const result = await api.get<Account[]>('accounts')
    return result.data
  },

  async getInvitations (): Promise<TournamentPlayer[]> {
    const api = useApi()
    const result = await api.get<TournamentPlayer[]>('accounts/mine/invitations')
    return result.data
  },

  async acceptInvitation (invitationId: number, gameUsername: string): Promise<TournamentPlayer> {
    const api = useApi()
    const result = await api.put(`accounts/mine/invitations/${invitationId}/accept/${gameUsername}`)
    return result.data
  },

  async rejectInvitation (invitationId: number): Promise<TournamentPlayer> {
    const api = useApi()
    const result = await api.put(`accounts/mine/invitations/${invitationId}/reject`)
    return result.data
  }
}
