<script lang="ts" setup>
import constants from '~/constants'

const tournamentsStore = useTournamentsStore()

const { event, listen } = useEventBus()
const emit = defineEmits(['finalize'])

const increaseEditStep = () => {
  tournamentsStore.increaseTournamentEditStep()

  if (tournamentsStore.isTournamentEditStepFinal) {
    emit('finalize')
  }
}

const increaseEditStepRequest = () => {
  event(constants.events.tournamentEditNextStepRequest)
}

listen(constants.events.tournamentEditNextStepConfirm, increaseEditStep)

const canIncrease = computed(() => tournamentsStore.canIncreaseTournamentEditStep)
</script>

<template>
  <CommonActionLink
    :disabled="!canIncrease"
    :label="$t('common.next')"
    @click="increaseEditStepRequest"
  />
</template>
