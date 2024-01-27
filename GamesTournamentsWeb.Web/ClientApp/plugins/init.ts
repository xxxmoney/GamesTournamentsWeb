export default async () => {
  const mainStore = useMainStore()
  const accountStore = useAccountStore()
  const tournamentsStore = useTournamentsStore()
  const gamesStore = useGamesStore()

  // TODO: figure out how to use i18n here
  //const { setLocale } = useI18n($i18n)

  await Promise.all([
    mainStore.initialize(),
    accountStore.initialize(),
    tournamentsStore.initialize(),
    gamesStore.initialize()
  ])

  //await $i18n.setLocale(mainStore.locale)
}
