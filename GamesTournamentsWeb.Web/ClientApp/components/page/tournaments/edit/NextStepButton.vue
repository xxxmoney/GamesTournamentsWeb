<script lang="ts" setup>
const tournamentsStore = useTournamentsStore()

const increaseEditStep = () => {
  tournamentsStore.increaseTournamentEditStep()
}
</script>

<template>
  <CommonActionLink
    :label="$t('common.next')"
    class="mx-auto"
    @click="increaseEditStep"
  />
</template>
