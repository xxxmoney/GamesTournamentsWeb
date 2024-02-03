<script lang="ts" setup>
const tournamentsStore = useTournamentsStore()

const tournaments = computed(() => tournamentsStore.tournaments)

await tournamentsStore.initialize()
</script>

<template>
  <div class="page-container">
    <CommonPanel :header="$t('common.filter')" class="w-full">
      <div class="flex md:inline-flex">
        <PageTournamentsFilter />
      </div>
    </CommonPanel>

    <div class="grid gap-xl grid-cols-1 lg:grid-cols-3">
      <PageTournamentsTournament
        v-for="tournament in tournaments"
        :id="tournament.id"
        :key="`tournament-${tournament.id}`"
      />
    </div>

    <Paginator :rows="10" :totalRecords="120"></Paginator>
  </div>
</template>
