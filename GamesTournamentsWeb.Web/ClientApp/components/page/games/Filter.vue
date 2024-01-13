<script lang="ts" setup>
const gamesStore = useGamesStore()

const filter = computed(() => gamesStore.filter)
const genres = computed(() => gamesStore.genres)
</script>

<template>
  <div class="form-container">
    <CommonInputText v-model="filter.name" :label="$t('common.name')" />

    <CommonWithLabel :label="$t('common.genre')">
      <Dropdown
        v-model="filter.genreId"
        :options="genres"
        :placeholder="$t('common.genre')"
        filter
        optionLabel="name"
        optionValue="id"
        showClear
      />
    </CommonWithLabel>

    <CommonWithLabel :label="$t('games.my_tournaments')">
      <Checkbox v-model="filter.withMyTournaments" :binary="true" />
    </CommonWithLabel>
  </div>
</template>
