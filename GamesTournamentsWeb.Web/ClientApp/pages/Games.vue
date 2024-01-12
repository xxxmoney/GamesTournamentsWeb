<script lang="ts" setup>
const gamesStore = useGamesStore()

const games = computed(() => gamesStore.games)

await gamesStore.initialize()
</script>

<template>
  <div class="inline-flex flex-col items-center gap-lg m-auto">
    <PageGamesFilter />

    <div class="grid gap grid-cols-1 lg:grid-cols-3">
      <PageGamesGame
        v-for="game in games"
        :id="game.id"
        :key="`game-${game.id}`"
        :name="game.name"
      />
    </div>
  </div>
</template>
