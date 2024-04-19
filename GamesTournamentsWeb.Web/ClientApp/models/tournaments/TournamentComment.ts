interface TournamentComment {
    id: number,
    tournamentId: number,
    accountId: number,
    text: string,
    createDate: Date
}

export type { TournamentComment }
