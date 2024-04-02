import { defineStore } from 'pinia'
import type { TournamentOverview } from '~/models/tournaments/TournamentOverview'
import { TournamentFilter } from '~/models/tournaments/TournamentFilter'
import type { Platform } from '~/models/tournaments/Platform'
import type { Region } from '~/models/tournaments/Region'
import type { Tournament } from '~/models/tournaments/Tournament'
import { TournamentsService } from '~/apiServices/TournamentsService'
import { TournamentEdit } from '~/models/tournaments/TournamentEdit'
import constants from '~/constants'
import type { Currency } from '~/models/tournaments/Currency'
import type { Match } from '~/models/tournaments/Match'
import { TournamentMapper } from '~/mappers/TournamentMapper'
import type { PagedResult } from '~/models/PagedResult'
import type { MatchEdit } from '~/models/tournaments/MatchEdit'

export const useTournamentsStore = defineStore({
  id: 'tournaments-store',
  state: () => ({
    loading: true,
    pagedTournaments: null as PagedResult<TournamentOverview> | null,
    paginatorFirst: 0,
    tournamentDetail: null as Tournament | null,
    tournamentEdit: new TournamentEdit().toJson() as TournamentEdit,
    tournamentEditStep: 0,
    teamSizes: [] as number[],
    regions: [] as Region[],
    platforms: [] as Platform[],
    currencies: [] as Currency[],
    filter: new TournamentFilter().toJson() as TournamentFilter
  }),
  actions: {
    async initialize (): Promise<void> {
      await Promise.all([
        this.getTournamentOverviews(),
        this.getTeamSizes(),
        this.getRegions(),
        this.getPlatforms(),
        this.getCurrencies()
      ])
    },

    async getTournamentOverviews (): Promise<TournamentOverview[]> {
      try {
        this.loading = true

        this.pagedTournaments = await TournamentsService.getTournamentOverviews(this.filter)
        return this.tournaments
      } finally {
        this.loading = false
      }
    },

    async getTeamSizes (): Promise<number[]> {
      try {
        this.loading = true

        this.teamSizes = await TournamentsService.getTeamSizes()
        return this.teamSizes
      } finally {
        this.loading = false
      }
    },

    async getRegions (): Promise<Region[]> {
      try {
        this.loading = true

        this.regions = await TournamentsService.getRegions()
        return this.regions
      } finally {
        this.loading = false
      }
    },

    async getPlatforms (): Promise<Platform[]> {
      try {
        this.loading = true

        this.platforms = await TournamentsService.getPlatforms()
        return this.platforms
      } finally {
        this.loading = false
      }
    },

    async getCurrencies (): Promise<Currency[]> {
      try {
        this.loading = true

        this.currencies = await TournamentsService.getCurrencies()
        return this.currencies
      } finally {
        this.loading = false
      }
    },

    async getTournamentById (tournamentId: number): Promise<Tournament> {
      try {
        this.loading = true

        this.tournamentDetail = await TournamentsService.getTournamentById(tournamentId)
        return this.tournamentDetail
      } finally {
        this.loading = false
      }
    },

    async upsertTournament (): Promise<Tournament> {
      try {
        this.loading = true

        return await TournamentsService.upsertTournament(this.tournamentEdit)
      } finally {
        this.loading = false
      }
    },

    async deleteTournamenById (tournamentId: number): Promise<void> {
      try {
        this.loading = true

        await TournamentsService.deleteTournamentById(tournamentId)
      } finally {
        this.loading = false
      }
    },

    async updateMatch (match: MatchEdit): Promise<Match[]> {
      try {
        this.loading = true

        const result = await TournamentsService.updateMatch(match)
        for (const updatedMatch of result) {
          const index = this.tournamentDetail!.matches.findIndex(m => m.id === updatedMatch.id)
          if (index !== undefined && index !== -1) {
                        this.tournamentDetail!.matches![index] = updatedMatch
          }
        }

        // Set end date if any updated next match winner
        const finalMatch = result.find(m => m.nextMatchId === null)
        if (finalMatch?.winner) {
                    this.tournamentDetail!.endDate = new Date()
        }

        return result
      } finally {
        this.loading = false
      }
    },

    mapTournamentDetailToEdit (accountId: number) {
      const match = this.tournamentDetailCurrentMatch
      this.tournamentEdit = TournamentMapper.mapTournamenDetailToEdit(this.tournamentDetail, match, accountId)
    },

    resetTournamentEdit (): void {
      this.tournamentEditStep = 0
      this.tournamentEdit = new TournamentEdit().toJson() as TournamentEdit
    },

    decreaseTournamentEditStep (): void {
      if (this.canDecreaseTournamentEditStep) {
        this.tournamentEditStep--
      }
    },

    increaseTournamentEditStep (): void {
      if (this.canIncreaseTournamentEditStep) {
        this.tournamentEditStep++
      }
    },

    resetTournamentEditStep (): void {
      this.tournamentEditStep = 0
    },

    resetFilter (): void {
      this.filter = new TournamentFilter().toJson() as TournamentFilter
    }

  },
  getters: {
    tournaments: (state) => {
      return state.pagedTournaments?.results ?? []
    },
    tournamentById: (state) => (id: number): TournamentOverview => {
      return (state.pagedTournaments?.results ?? []).find(game => game.id === id) as TournamentOverview
    },
    tournamentDetailCurrentMatch: (state): Match | null => {
      return state.tournamentDetail?.matches?.find(match => match.isRunning) ?? null
    },
    isTournamentDetailFinished: (state): boolean => {
      return !!state.tournamentDetail?.endDate
    },
    isTournamentDetailStarted: (state): boolean => {
      return !!state.tournamentDetail?.startDate && new Date(state.tournamentDetail.startDate).getUTCDate() < new Date().getUTCDate()
    },
    currencyById: (state) => (id: number): Currency => {
      return state.currencies.find(currency => currency.id === id) as Currency
    },
    canDecreaseTournamentEditStep (state): boolean {
      return state.tournamentEditStep > 0
    },
    canIncreaseTournamentEditStep (state): boolean {
      return state.tournamentEditStep < constants.tournamentEditStepCount
    },
    isTournamentEditStepFinal (state): boolean {
      return state.tournamentEditStep === constants.tournamentEditStepCount
    }
  }
})

if (import.meta.hot) {
  import.meta.hot.accept(acceptHMRUpdate(useTournamentsStore, import.meta.hot))
}
