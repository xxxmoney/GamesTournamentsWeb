<script lang="ts" setup>
import type { PageState } from 'primevue/paginator'

const tournamentsStore = useTournamentsStore()

const pagedTournamentOverviews = computed(() => tournamentsStore.pagedTournaments)
const tournamentOverviews = computed(() => tournamentsStore.tournaments)

await tournamentsStore.initialize()

// const first = computed(() => (tournamentsStore.filter.page - 1) * (pagedTournamentOverviews.value?.pageSize ?? 0))
const first = ref(0)

const onPage = async (value: PageState) => {
  tournamentsStore.filter.page = value.page
  await tournamentsStore.getTournamentOverviews()
}
</script>

<template>
  <div class="page-container">
    <CommonPanel :header="$t('common.filter')" class="w-full">
      <div class="flex md:inline-flex">
        <PageTournamentsFilter />
      </div>
    </CommonPanel>

    <div class="grid gap-xl grid-cols-1 lg:grid-cols-3">
      <PageTournamentsOverview
        v-for="tournamentOverview in tournamentOverviews"
        :id="tournamentOverview.id"
        :key="`tournament-${tournamentOverview.id}`"
      />
    </div>

    <Paginator
      v-model:first="first"
      :rows="pagedTournamentOverviews?.pageSize ?? 0"
      :totalRecords="pagedTournamentOverviews?.rowCount ?? 0"
      @page="onPage"
    ></Paginator>
  </div>
</template>
