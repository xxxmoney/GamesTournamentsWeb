<script lang="ts" setup>
const tournamentsStore = useTournamentsStore()

const decreaseEditStep = () => {
  tournamentsStore.decreaseTournamentEditStep()
}

const canDecrease = computed(() => tournamentsStore.canDecreaseTournamentEditStep)
</script>

<template>
  <CommonActionLink
    :disabled="!canDecrease"
    :labelRight="$t('common.previous')"
    iconClass="pi pi-arrow-left"
    @click="decreaseEditStep"
  />
</template>
