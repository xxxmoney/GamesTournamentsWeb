<script lang="ts" setup>
const tournamentsStore = useTournamentsStore()

const tournaments = computed(() => tournamentsStore.tournaments)

await tournamentsStore.initialize()
</script>

<template>
  <div class="page-container">
    <PageTournamentsFilter />

    <div class="grid gap-xl grid-cols-1 lg:grid-cols-3">
      <PageTournamentsTournament
        v-for="tournament in tournaments"
        :id="tournament.id"
        :key="`tournament-${tournament.id}`"
      />
    </div>
  </div>
</template>
