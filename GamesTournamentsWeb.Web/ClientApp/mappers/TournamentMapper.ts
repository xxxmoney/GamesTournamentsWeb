import type { Tournament } from '~/models/tournaments/Tournament'
import { TournamentEdit } from '~/models/tournaments/TournamentEdit'
import type { Match } from '~/models/tournaments/Match'
import { copyObject } from '~/utils/objectUtils'

export const TournamentMapper = {
  mapTournamenDetailToEdit (tournamentDetail: Tournament, match: Match | null): TournamentEdit {
    const edit = new TournamentEdit()
    edit.id = tournamentDetail.id
    edit.name = tournamentDetail.name
    edit.teamSize = tournamentDetail.teamSize
    edit.gameId = tournamentDetail.game.id
    edit.platformId = tournamentDetail.platform.id
    edit.regionIds = tournamentDetail.regions.map(region => region.id)
    edit.startDate = tournamentDetail.startDate
    edit.endDate = tournamentDetail.endDate
    edit.info = tournamentDetail.info
    edit.rules = tournamentDetail.rules
    edit.settings = tournamentDetail.settings
    edit.prizes = tournamentDetail.prizes.map(prize => copyObject(prize))
    edit.players = tournamentDetail.players.map(player => copyObject(player))
    edit.match = copyObject(match)
    edit.streams = tournamentDetail.streams.map(stream => copyObject(stream))
    edit.minimumPlayers = tournamentDetail.minimumPlayers
    edit.maximumPlayers = tournamentDetail.maximumPlayers
    if (tournamentDetail.prizes.length) {
      edit.currencyId = tournamentDetail.prizes[0].currencyId
    }
    edit.anyoneCanJoin = tournamentDetail.anyoneCanJoin
    edit.adminIds = [...tournamentDetail.adminIds]

    return edit.toJson() as TournamentEdit
  }
}
