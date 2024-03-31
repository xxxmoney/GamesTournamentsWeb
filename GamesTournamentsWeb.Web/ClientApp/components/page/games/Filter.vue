<script lang="ts" setup>
import constants from '~/constants'

const gamesStore = useGamesStore()

const filter = computed(() => gamesStore.filter)
const genres = computed(() => gamesStore.genres)

const getGames = async () => {
  filter.value.page = 1
  gamesStore.paginatorFirst = 0
  await gamesStore.getGames()
}
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

    <div class="inline-flex flex-col justify-center">
      <Button :label="$t('common.search')" icon="pi pi-search" @click="getGames" />
    </div>
  </div>
</template>
