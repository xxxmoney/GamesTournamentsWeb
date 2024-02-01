export default {
  test: 'Test EN',
  common: {
    pages: 'Pages',
    email: 'E-mail',
    password: 'Password',
    confirm_password: 'Confirm password',
    login: 'Login',
    logout: 'Logout',
    register: 'Register',
    username: 'Username',
    try_now: 'Try now',
    name: 'Name',
    surname: 'Surname',
    message: 'Message',
    submit: 'Submit',
    genre: 'Genre',
    detail: 'Detail',
    my_tournaments: 'My tournaments',
    tournaments: 'Tournaments',
    my_dashboard: 'My dashboard',
    starts_in: 'Starts in',
    team_size: 'Team size',
    region: 'Region',
    platform: 'Platform',
    filter: 'Filter',
    error: 'Error',
    error_description: 'Something went wrong. Please try again.',
    success: 'Success',
    success_description: 'Action was successfully completed.',
    info: 'Info',
    matches_played: 'Matches played',
    win_rate: 'Win rate',
    history: 'History',
    change_password: 'Change password',
    password_change: 'Password change',
    delete_account: 'Delete account',
    current_password: 'Current password',
    new_password: 'New password',
    confirm_new_password: 'Confirm new password',
    nickname: 'Nickname',
    game: 'Game',
    place: 'Place',
    link: 'Link'
  },

  locales: {
    en: 'English',
    cs: 'Czech'
  },

  enums: {
    region: {
      europe: 'Europe',
      north_america: 'North America',
      asia: 'Asia'
    },
    platform: {
      pc: 'PC',
      playstation: 'Playstation',
      xbox: 'Xbox'
    }
  },

  pages: {
    home: 'Home',
    tournaments: 'Tournaments',
    games: 'Games',
    dashboard: 'Dashboard',
    login: 'Login',
    logout: 'Logout',
    register: 'Register',
    account: 'Account',
    about: 'About',
    contact: 'Contact',
    privacy: 'Privacy',
    terms: 'Terms'
  },

  password: {
    prompt: 'Enter password',
    weak: 'Weak',
    medium: 'Average',
    strong: 'Strong'
  },

  home: {
    hero: {
      small_title: 'Games tournaments web',
      title: 'The Next Gen Website For Multiplayer Tournaments',
      description: 'Unleash your inner gamer with our multiplayer game tournaments, a global platform for strategy, competition, and camaraderie. Join the battle today!'
    },
    features: {
      create_tournaments: {
        icon: 'pi-star',
        title: 'Create Tournaments',
        description: 'Host your own tournaments, control every detail, and watch your event come alive!'
      },
      real_time_updates: {
        icon: 'pi-star',
        title: 'Real Time Updates',
        description: 'Stay updated with real-time tournament statuses, ensuring you\'re never late to the action.'
      },
      stats_insights: {
        icon: 'pi-star',
        title: 'Stats & Insights',
        description: 'Dive deep into past tournaments with comprehensive stats and insights, helping you make informed decisions.'
      }
    },
    contact_form: {
      title: 'Contact us',
      subtitle: 'We\'d love to hear from you!',
      info: 'Fields with * are required.'
    }
  },
  login: {
    success: 'You have been successfully logged in.'
  },
  register: {
    success: 'You have been successfully registered.'
  },
  change_password: {
    password_not_matching: 'Passwords do not match.',
    password_incorrect: 'Current password is incorrect.',
    success: 'Password has been successfully changed.'
  },
  delete_account: {
    success: 'Account has been successfully deleted.',
    prompt: 'Are you sure you want to delete your account?'
  },

  tournament_detail: {
    overview: 'Overview',
    rules: 'Rules',
    prizes: 'Prizes',
    players: 'Players',
    matches: 'Matches',
    streams: 'Streams',
    admin: 'Admin'
  },
  tournament_prizes: {
    place: 'Place',
    first_place: 'First place',
    second_place: 'Second place',
    third_place: 'Third place',
    amount: 'Amount',
    other_prizes: 'Other prizes'
  },
  tournament_players: {
    username: 'Username',
    status: 'Status',
    game_username: 'Game username'
  },
  tournament_player_status: {
    pending: 'Čeká na schválení',
    accepted: 'Přijato',
    rejected: 'Odmítnuto'
  }

}
