<script lang="ts" setup>
const tournamentsStore = useTournamentsStore()

const emit = defineEmits(['finalize'])

const increaseEditStep = () => {
  tournamentsStore.increaseTournamentEditStep()

  if (tournamentsStore.isTournamentEditStepFinal) {
    emit('finalize')
  }
}

const canIncrease = computed(() => tournamentsStore.canIncreaseTournamentEditStep)
</script>

<template>
  <CommonActionLink
    :disabled="!canIncrease"
    :label="$t('common.next')"
    @click="increaseEditStep"
  />
</template>
