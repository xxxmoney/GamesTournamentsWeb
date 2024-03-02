import constants from '~/constants'

export const useTournamentEditNextStepRequestWithValidate = (stepOfTab: number, validate: () => Promise<boolean>) => {
  const step = useTournamentEditStep()
  const { event, listen, disconnect } = useEventBus()

  const handler = async () => {
    if (step.value === stepOfTab && await validate()) {
      event(constants.events.tournamentEditNextStepConfirm)
    }
  }

  onMounted(() => {
    disconnect(constants.events.tournamentEditNextStepRequest)
    listen(constants.events.tournamentEditNextStepRequest, handler)
  })
  onUnmounted(() => {
    disconnect(constants.events.tournamentEditNextStepRequest, handler)
  })
}
