<script lang="ts" setup>
const { id } = defineProps({
  id: {
    type: Number,
    required: true
  }
})

const tournamentsStore = useTournamentsStore()

await tournamentsStore.getTournamentDetailById(id)

const detail = computed(() => tournamentsStore.tournamentDetail)
</script>

<template>
  <div class="container-gap">
  </div>
</template>
