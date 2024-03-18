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

export const useTournamentsStore = defineStore({
  id: 'tournaments-store',
  state: () => ({
    loading: true,
    pagedTournaments: null as PagedResult<TournamentOverview> | null,
    paginatorFirst: 0 as Number,
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

    mapTournamentDetailToEdit () {
      const match = this.tournamentDetailCurrentMatch
      this.tournamentEdit = TournamentMapper.mapTournamenDetailToEdit(this.tournamentDetail!, match)
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
