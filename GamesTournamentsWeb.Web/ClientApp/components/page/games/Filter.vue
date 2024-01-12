<script lang="ts" setup>
const gamesStore = useGamesStore()

const filter = computed(() => gamesStore.filter)
const genres = computed(() => gamesStore.genres)
</script>

<template>
  <div class="form-container">
    <CommonInputText v-model="filter.name" :label="$t('common.name')" />
    <CommonDropdown v-model="filter.genreId" :label="$t('common.genre')" :options="genres" />
  </div>
</template>

<style scoped>

</style>
