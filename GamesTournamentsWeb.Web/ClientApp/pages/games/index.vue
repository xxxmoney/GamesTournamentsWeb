<script lang="ts" setup>
import type { PageState } from 'primevue/paginator'

const gamesStore = useGamesStore()

const pagedGames = computed(() => gamesStore.pagedGames)
const games = computed(() => gamesStore.games)

await gamesStore.initialize()

const first = computed({
  get: () => gamesStore.paginatorFirst,
  set: (value) => {
    gamesStore.paginatorFirst = value
  }
})

const onPage = async (value: PageState) => {
  gamesStore.filter.page = value.page + 1
  await gamesStore.getGames()
}
</script>

<template>
  <div class="page-container">
    <CommonPanel :header="$t('common.filter')" class="w-full overflow-auto">
      <div class="flex md:inline-flex">
        <PageGamesFilter />
      </div>
    </CommonPanel>

    <div class="grid gap-xl grid-cols-1 lg:grid-cols-3">
      <PageGamesGame
        v-for="game in games"
        :id="game.id"
        :key="`game-${game.id}`"
      />
    </div>

    <Paginator
      v-model:first="first"
      :rows="pagedGames?.pageSize ?? 0"
      :totalRecords="pagedGames?.rowCount ?? 0"
      @page="onPage"
    ></Paginator>
  </div>
</template>
