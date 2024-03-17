<script lang="ts" setup>
const { id } = defineProps({
  id: {
    type: Number,
    default: null
  }
})

// TODO: add to store tournament edit

const store = useTournamentsStore()
if (id) {
  await store.getTournamentById(id)
}

store.resetTournamentEdit()
store.mapTournamentDetailToEdit()
</script>

<template>
  <PageTournamentsEditSteps class="w-full" />
</template>
