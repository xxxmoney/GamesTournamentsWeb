<script lang="ts" setup>
const gamesStore = useGamesStore()

const games = computed(() => gamesStore.games)

await gamesStore.initialize()
</script>

<template>
  <div class="page-container">
    <CommonPanel :header="$t('common.filter')" class="w-full">
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

    <Paginator :rows="10" :totalRecords="120"></Paginator>
  </div>
</template>
