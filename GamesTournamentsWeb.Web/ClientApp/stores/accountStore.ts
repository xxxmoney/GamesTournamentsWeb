import { defineStore } from 'pinia'
import type { AccountInfo } from '~/models/user/AccountInfo'
import type { HistoryItem } from '~/models/user/HistoryItem'
import { AccountService } from '~/apiServices/AccountService'
import type { Account } from '~/models/user/Account'
import type { TournamentPlayer } from '~/models/tournaments/TournamentPlayer'

export const useAccountStore = defineStore({
  id: 'account-store',
  state: () => ({
    loading: true,
    accounts: [] as Account[],
    info: null as AccountInfo | null,
    history: [] as HistoryItem[],
    invitations: [] as TournamentPlayer[],
    passwordChangeModalActive: false,
    historyModalActive: false,
    invitationsModalActive: false
  }),
  actions: {
    async initialize (): Promise<void> {
      await Promise.all([
        this.getAccounts()
      ])

      this.loading = false
    },

    async getAccountInfo (): Promise<AccountInfo> {
      try {
        this.loading = true

        this.info = await AccountService.getAccountInfo()
        return this.info
      } finally {
        this.loading = false
      }
    },

    async getHistory (): Promise<HistoryItem[]> {
      try {
        this.loading = true

        this.history = await AccountService.getHistory()
        return this.history
      } finally {
        this.loading = false
      }
    },

    async getInvitations (): Promise<TournamentPlayer[]> {
      try {
        this.loading = true

        this.invitations = await AccountService.getInvitations()
        return this.invitations
      } finally {
        this.loading = false
      }
    },

    async acceptInvitation (invitationId: number, gameUsername: string): Promise<TournamentPlayer> {
      try {
        this.loading = true

        const invitation = await AccountService.acceptInvitation(invitationId, gameUsername)
        const index = this.invitations.findIndex(i => i.id === invitationId)
        if (index >= 0) {
          this.invitations[index] = invitation
        }

        return invitation
      } finally {
        this.loading = false
      }
    },

    async rejectInvitation (invitationId: number): Promise<TournamentPlayer> {
      try {
        this.loading = true

        const invitation = await AccountService.rejectInvitation(invitationId)
        const index = this.invitations.findIndex(i => i.id === invitationId)
        if (index >= 0) {
          this.invitations[index] = invitation
        }

        return invitation
      } finally {
        this.loading = false
      }
    },

    async getAccounts (): Promise<Account[]> {
      try {
        this.loading = true

        this.accounts = await AccountService.getAccounts()
        return this.accounts
      } finally {
        this.loading = false
      }
    },

    openPasswordChangeModal (): void {
      this.passwordChangeModalActive = true
    },
    closePasswordChangeModal (): void {
      this.passwordChangeModalActive = false
    },

    openHistoryModal (): void {
      this.historyModalActive = true
    },
    closeHistoryModal (): void {
      this.historyModalActive = false
    },

    openInvitationsModal (): void {
      this.invitationsModalActive = true
    },
    closeInvitationsModal (): void {
      this.invitationsModalActive = false
    }

  },
  getters: {}
})

if (import.meta.hot) {
  import.meta.hot.accept(acceptHMRUpdate(useAccountStore, import.meta.hot))
}
