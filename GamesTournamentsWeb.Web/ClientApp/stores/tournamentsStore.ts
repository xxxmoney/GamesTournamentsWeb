import { defineStore } from 'pinia'
import type { Tournament } from '~/models/tournaments/Tournament'
import { TournamentFilter } from '~/models/tournaments/TournamentFilter'
import type { Platform } from '~/models/tournaments/Platform'
import type { Region } from '~/models/tournaments/Region'
import type { TournamentDetail } from '~/models/tournaments/TournamentDetail'
import { TournamentsService } from '~/apiServices/TournamentsService'
import { TournamentEdit } from '~/models/tournaments/TournamentEdit'
import constants from '~/constants'
import type { Currency } from '~/models/tournaments/Currency'
import type { Match } from '~/models/tournaments/Match'

export const useTournamentsStore = defineStore({
  id: 'tournaments-store',
  state: () => ({
    tournaments: [] as Tournament[],
    tournamentDetail: null as TournamentDetail | null,
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
        this.getTournaments(),
        this.getTeamSizes(),
        this.getRegions(),
        this.getPlatforms(),
        this.getCurrencies()
      ])
    },

    async getTournaments (): Promise<Tournament[]> {
      this.tournaments = await TournamentsService.getTournaments(this.filter)
      return this.tournaments
    },

    async getTeamSizes (): Promise<number[]> {
      this.teamSizes = await TournamentsService.getTeamSizes()
      return this.teamSizes
    },

    async getRegions (): Promise<Region[]> {
      this.regions = await TournamentsService.getRegions()
      return this.regions
    },

    async getPlatforms (): Promise<Platform[]> {
      this.platforms = await TournamentsService.getPlatforms()
      return this.platforms
    },

    async getCurrencies (): Currency[] {
      this.currencies = await TournamentsService.getCurrencies()
      return this.currencies
    },

    async getTournamentDetailById (tournamentId: number): Promise<TournamentDetail> {
      this.tournamentDetail = await TournamentsService.getTournamentDetailById(tournamentId)
      return this.tournamentDetail
    },

    mapTournamentDetailToEdit () {
      // TODO: add whole mapping - check for detail being null - insert

      this.tournamentEdit.match = this.tournamentDetailCurrentMatch
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
    tournamentById: (state) => (id: number): Tournament => {
      return state.tournaments.find(game => game.id === id) as Tournament
    },
    tournamentDetailCurrentMatch: (state): Match | null => {
      return state.tournamentDetail?.matches?.find(match => match.isRunning)
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
