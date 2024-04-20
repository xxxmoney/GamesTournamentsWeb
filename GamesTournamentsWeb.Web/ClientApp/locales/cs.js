export default {
  testAuthentication: 'Test CS',
  common: {
    delete: 'Smazat',
    search: 'Vyhledat',
    select: 'Vybrat',
    choose_module: 'Vyberte modul',
    add_module: 'Přidat modul',
    change_module: 'Změnit modul',
    delete_module: 'Odebrat modul',
    module: 'Modul',
    create: 'Vytvořit',
    do_create: 'Vytvořte',
    update: 'Aktualizovat',
    view: 'Pohled',
    choose_view: 'Vyberte pohled',
    add_view: 'Přidat pohled',
    update_view: 'Aktualizovat pohled',
    save: 'Uložit',
    pages: 'Stránky',
    email: 'E-mail',
    password: 'Heslo',
    confirm_password: 'Potvrzení hesla',
    login: 'Přihlásit se',
    logout: 'Odhlásit se',
    register: 'Registrovat se',
    username: 'Uživatelské jméno',
    try_now: 'Vyzkoušejte nyní',
    name: 'Jméno',
    surname: 'Příjmení',
    message: 'Zpráva',
    submit: 'Odeslat',
    genre: 'Žánr',
    detail: 'Detail',
    my_tournaments: 'Moje turnaje',
    tournaments: 'Turnaje',
    my_dashboard: 'Můj dashboard',
    starts_in: 'Začíná za',
    team_size: 'Velikost týmu',
    region: 'Region',
    platform: 'Platforma',
    filter: 'Filtr',
    error: 'Chyba',
    error_description: 'Něco se pokazilo, zkuste to prosím znovu',
    success: 'Úspěch',
    success_description: 'Akce byla úspěšně dokončena.',
    info: 'Info',
    matches_played: 'Hrané zápasy',
    win_rate: 'Vyhrané zápasy',
    history: 'Historie',
    change_password: 'Změnit heslo',
    password_change: 'Změna hesla',
    delete_account: 'Smazat účet',
    current_password: 'Současné heslo',
    new_password: 'Nové heslo',
    confirm_new_password: 'Potvrzení nového hesla',
    nickname: 'Přezdívka',
    game: 'Hra',
    place: 'Místo',
    link: 'Odkaz',
    video_not_supported: 'Váš prohlížeč nepodporuje toto video.',
    stream: 'Stream',
    start_date: 'Datum začátku',
    minimum_players: 'Nejméně hráčů',
    maximum_players: 'Nejvíce hráčů',
    description: 'Popis',
    previous: 'Předchozí',
    next: 'Další',
    rules: 'Pravidla',
    prize: 'Cena',
    currency: 'Měna',
    stream_url: 'Odkaz na stream',
    stream_name: 'Název streamu',
    player: 'Hráč',
    account: 'Account',
    admin: 'Administrátor',
    confirmation: 'Potvrzení',
    winner: 'Vítěz',
    choose_game: 'Vyberte hru',
    choose_platform: 'Vyberte platformu',
    choose_regions: 'Vyberte regiony',
    choose_team_size: 'Vyberte velikost týmu',
    choose_account: 'Vyberte účet',
    status: 'Stav',
    game_username: 'Herní přezdívka',
    tournament_name: 'Název turnaje',
    invitations: 'Pozvánky',
    accept: 'Přijmout',
    reject: 'Odmítnout',
    actions: 'Akce',
    set_nickname: 'Nastavit přezdívku',
    settings: 'Nastavení',
    has_ended: 'Skončil',
    create_date: 'Datum vytvoření',
    text: 'Text'
  },

  validations: {
    undefined: 'Pole je nevalidní',
    error: 'Chyba při validaci',
    required: 'Pole je povinné',
    requiredIf: 'Pole je povinné',
    requiredUnless: 'Pole je povinné',
    minLength: 'Minimální délka je {min}',
    maxLength: 'Maximální délka je {max}',
    url: 'Neplatný odkaz',
    email: 'Neplatný e-mail',
    sameAsPassword: 'Hesla se neshodují',
    sameAsNewPassword: 'Nová hesla se neshodují'
  },

  locales: {
    en: 'Anglicky',
    cs: 'Česky'
  },

  currencies: {
    usd: 'Dolar',
    eur: 'Euro',
    gbp: 'Libra',
    czk: 'Česká koruna'
  },

  enums: {
    region: {
      europe: 'Evropa',
      north_america: 'Severní Amerika',
      south_america: 'Jižní Amerika',
      asia: 'Asie'
    },
    platform: {
      pc: 'PC',
      playstation: 'Playstation',
      xbox: 'Xbox'
    }
  },

  pages: {
    home: 'Domů',
    tournaments: 'Turnaje',
    games: 'Hry',
    dashboard: 'Nástěnka',
    login: 'Příhlášení',
    logout: 'Odhlášení',
    register: 'Registrace',
    account: 'Účet',
    about: 'O nás',
    contact: 'Kontakt',
    privacy: 'Soukromí',
    terms: 'Podmínky'
  },

  password: {
    prompt: 'Zadejte heslo',
    weak: 'Slabé',
    medium: 'Průměrné',
    strong: 'Silné'
  },

  home: {
    hero: {
      small_title: 'Web pro herní turnaje',
      title: 'Stránka Nové Generace Pro Multiplayerové Turnaje',
      description: 'Uvolněte své hráčské srdce v našich herních turnajích pro více hráčů, které jsou globální platformou pro strategii, soutěž a kamarádství. Zapojte se do bitvy ještě dnes!'
    },
    features: {
      create_tournaments: {
        icon: 'pi-star',
        title: 'Vytvářejte turnaje',
        description: 'Hostujte své vlastní turnaje a ovládejte každý detail!'
      },
      real_time_updates: {
        icon: 'pi-star',
        title: 'Aktualizace v reálném čase',
        description: 'Sledujte aktuální stavy turnajů v reálném čase, abyste nikdy nepřišli pozdě do akce'
      },
      stats_insights: {
        icon: 'pi-star',
        title: 'Statistiky a postřehy',
        description: 'Ponořte se do minulých turnajů se statistikami a přehledy, které vám pomohou činit informovaná rozhodnutí'
      }
    },
    contact_form: {
      title: 'Kontaktujte nás',
      subtitle: 'Rádi od Vás uslyšíme!',
      info: 'Pole s * jsou povinná'
    }
  },
  login: {
    success: 'Byli jste úspěšně přihlášeni'
  },
  register: {
    success: 'Byli jste úspěšně zaregistrováni'
  },
  change_password: {
    password_not_matching: 'Hesla se neshodují',
    password_incorrect: 'Současné heslo je nesprávné',
    success: 'Heslo bylo úspěšně změněno'
  },
  account_delete: {
    success: 'Účet byl úspěšně smazán',
    prompt: 'Opravdu chcete smazat svůj účet?'
  },

  account_detail: {
    invitation_accept_confirm: 'Opravdu chcete přijmout pozvánku?',
    invitation_reject_confirm: 'Opravdu chcete odmítnout pozvánku?'
  },

  tournament_detail: {
    overview: 'Přehled',
    rules: 'Pravidla',
    prizes: 'Ceny',
    players: 'Hráči',
    matches: 'Zápasy',
    streams: 'Streamy',
    admin: 'Admin',
    comments: 'Komentáře'
  },
  tournament_matches: {
    no_matches: 'Nyní neprobíhají žádné zápasy',
    start_match: 'Začít zápas'
  },
  tournament_streams: {
    no_streams: 'Nejsou k dispozici žádné streamy'
  },
  tournament_prizes: {
    place: 'Místo',
    first_place: 'První místo',
    second_place: 'Druhé místo',
    third_place: 'Třetí místo',
    amount: 'Částka',
    other_prizes: 'Další ceny'
  },
  tournament_players: {
    username: 'Uživatelské jméno',
    status: 'Stav',
    join_tournament: 'Připojit se k turnaji',
    tip_winner: 'Myslím si, že toto bude vítěz',
    confirm_winner: 'Opravdu si myslíte, že toto bude vítěz?',
    expected_winner_chart: 'Očekávaný graf vítěze',
    no_expected_winner_statistics: 'Zatím zde nejsou žádné statistiky o očekávaném vítězi'
  },
  tournament_player_status: {
    pending: 'Čeká se na schválení',
    accepted: 'Přijato',
    rejected: 'Odmítnuto'
  },
  tournament_comments: {
    add_comment: 'Přidat komentář'
  },
  tournament_admin: {
    edit: 'Upravit turnaj',
    delete: 'Smazat turnaj'
  },
  tournament_delete: {
    success: 'Turnaj byl úspěšně smazán',
    prompt: 'Opravdu chcete smazat tento turnaj?'
  },
  tournament_edit: {
    steps: {
      info: 'Informace',
      rules: 'Pravidla',
      prizes: 'Ceny',
      players: 'Hráči',
      streams: 'Streamy',
      admins: 'Správci',
      overview: 'Přehled',
      finish: 'Dokončit'
    },
    write_info_tooltip: 'Napište stručný popis turnaje',
    write_rules_tooltip: 'Napište pravidla',
    add_prize_tooltip: 'Klikněte pro přidání ceny',
    add_stream_tooltip: 'Klikněte pro přidání odkazu na stream',
    can_anyone_join: 'Může se připojit kdokoliv?',
    no_match: 'Teď neprobíhá žádný zápas',
    success: 'Turnaj byl úspěšně upraven',
    confirm: 'Opravdu chcete dokončit úpravu turnaje?'
  },
  dashboard: {
    title: 'Nástěnka',
    new_view: 'Nový pohled',
    no_view: {
      title: 'Nebyl vybrán žádný pohled',
      subtitle: 'Neváhejte vybrat nebo {create} pohled'
    },
    modules: {
      tournament_history: {
        title: 'Historie turnajů'
      },
      win_loss_ratio: {
        title: 'Poměr výher a proher',
        win_count: 'Počet výher',
        loss_count: 'Počet proher',
        player_no_matches: 'Zatím hráč nedohrál žádný zápas'
      }
    }
  }

}
