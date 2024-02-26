<script lang="ts" setup>
import constants from '~/constants'

const gamesStore = useGamesStore()

const filter = computed(() => gamesStore.filter)
const genres = computed(() => gamesStore.genres)
</script>

<template>
  <div class="inline-flex flex-col md:flex-row w-full gap">
    <CommonInputText v-model="filter.name" :label="$t('common.name')" />

    <CommonWithLabel :label="$t('common.genre')">
      <MultiSelect
        v-model="filter.genreIds"
        :options="genres"
        :placeholder="$t('common.genre')"
        :virtualScrollerOptions="{ itemSize: constants.virtualScrollHeight }"
        class="w-full"
        display="chip"
        optionLabel="name"
        optionValue="id"
      />
    </CommonWithLabel>

    <CommonWithLabel :label="$t('common.my_tournaments')">
      <Checkbox v-model="filter.withMyTournaments" :binary="true" />
    </CommonWithLabel>
  </div>
</template>
