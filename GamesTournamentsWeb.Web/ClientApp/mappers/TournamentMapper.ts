import type { Tournament } from '~/models/tournaments/Tournament'
import { TournamentEdit } from '~/models/tournaments/TournamentEdit'
import type { Match } from '~/models/tournaments/Match'
import { copyObject } from '~/utils/objectUtils'

export const TournamentMapper = {
  mapTournamenDetailToEdit (tournamentDetail: Tournament | null, accountId: number): TournamentEdit {
    const edit = new TournamentEdit()
    edit.id = tournamentDetail?.id ?? null
    edit.name = tournamentDetail?.name ?? null
    edit.teamSize = tournamentDetail?.teamSize ?? null
    edit.gameId = tournamentDetail?.game.id ?? null
    edit.platformId = tournamentDetail?.platform.id ?? null
    edit.regionIds = tournamentDetail?.regions.map(region => region.id) ?? []
    edit.startDate = tournamentDetail?.startDate ?? null
    edit.endDate = tournamentDetail?.endDate ?? null
    edit.info = tournamentDetail?.info ?? null
    edit.rules = tournamentDetail?.rules ?? null
    edit.prizes = tournamentDetail?.prizes.map(prize => copyObject(prize)) ?? []
    edit.players = tournamentDetail?.players.map(player => copyObject(player)) ?? []
    edit.streams = tournamentDetail?.streams.map(stream => copyObject(stream)) ?? []
    edit.minimumPlayers = tournamentDetail?.minimumPlayers ?? null
    edit.maximumPlayers = tournamentDetail?.maximumPlayers ?? null
    if (tournamentDetail?.prizes.length) {
      edit.currencyId = tournamentDetail.prizes[0].currencyId
    }
    edit.anyoneCanJoin = tournamentDetail?.anyoneCanJoin ?? false
    edit.adminIds = [...tournamentDetail?.admins.map(admin => admin.id) ?? [accountId]]

    return edit.toJson() as TournamentEdit
  }
}
