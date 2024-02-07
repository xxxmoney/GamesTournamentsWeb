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

  tournamentEditStepCount: 9
}
