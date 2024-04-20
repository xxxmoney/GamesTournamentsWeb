<script lang="ts" setup>
import type { PageState } from 'primevue/paginator'

const router = useRouter()
const tournamentsStore = useTournamentsStore()

const isLoggedIn = useIsLoggedIn()
const pagedTournamentOverviews = computed(() => tournamentsStore.pagedTournaments)
const tournamentOverviews = computed(() => tournamentsStore.tournaments)

await tournamentsStore.initialize()

const first = computed({
  get: () => tournamentsStore.paginatorFirst,
  set: (value) => {
    tournamentsStore.paginatorFirst = value
  }
})

const onPage = async (value: PageState) => {
  tournamentsStore.filter.page = value.page + 1
  await tournamentsStore.getTournamentOverviews()
}

const goToCreateTournament = async () => {
  await router.push('/tournaments/create')
}
</script>

<template>
  <div class="page-container">
    <Button v-if="isLoggedIn" :label="$t('common.create')" @click="goToCreateTournament" />

    <CommonPanel :header="$t('common.filter')" class="w-full overflow-auto">
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
