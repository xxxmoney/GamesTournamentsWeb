export const useIsTournamentAdmin = () => {
  const mainStore = useMainStore()
  const detail = useTournamentDetail()

  return computed(() => mainStore.account && (detail.value?.admins?.some(admin => admin.id === mainStore.account!.id) ?? false))
}
