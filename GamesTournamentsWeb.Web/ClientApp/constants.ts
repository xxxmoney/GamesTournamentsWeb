export default {
  features: [
    'create_tournaments',
    'real_time_updates',
    'stats_insights'
  ],

  carouselImages: [
    'assetto_corsa.jpg',
    'counter_strike_global_offensive.png',
    'league_of_legends.jpeg',
    'rocket_league.jpg',
    'valorant.png',
    'war_thunder.jpg'
  ],

  virtualScrollHeight: 34,

  toastErrorLifeTime: 3000,
  toastSuccessLifeTime: 2000,
  toastInfoLifeTime: 3000,

  loginKey: 'games-tournaments-web-login-result',

  defaultProfileImageUrl: '/img/profile.jpg',

  localeKey: 'games-tournaments-web-locale',
  locales: [
    'en',
    'cs'
  ],
  defaultLocale: 'en',

  tournamentEditMaximumPlayers: 256,

  tournamentEditSteps: {
    info: 0,
    rules: 1,
    prizes: 2,
    players: 3,
    match: 4,
    streams: 5,
    admins: 6,
    overview: 7
  },
  tournamentEditStepCount: 8,

  defaultCurrencyId: 1,

  defaultLayoutMaxRows: Infinity,
  defaultLayoutMaxCols: 6,
  defaultLayoutRowHeight: 100,
  defaultLayoutItemWidth: 2,
  defaultLayoutItemHeight: 2,

  dialogBaseIndexZ: 10000,

  events: {
    tournamentEditNextStepRequest: 'tournament-edit-step-next-request',
    tournamentEditNextStepConfirm: 'tournament-edit-step-next-confirm'
  }
}
