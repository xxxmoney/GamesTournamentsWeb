<script lang="ts" setup>
import constants from '~/constants'

const gamesStore = useGamesStore()

const isLoggedIn = useIsLoggedIn()

const filter = computed(() => gamesStore.filter)
const genres = computed(() => gamesStore.genres)

const getGames = () => gamesStore.getGames()
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

    <CommonWithLabel v-if="isLoggedIn" :label="$t('common.my_tournaments')">
      <Checkbox v-model="filter.withMyTournaments" :binary="true" />
    </CommonWithLabel>

    <Button :label="$t('common.search')" icon="pi pi-search" @click="getGames" />
  </div>
</template>
