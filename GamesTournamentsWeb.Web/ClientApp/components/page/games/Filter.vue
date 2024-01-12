<script lang="ts" setup>
const gamesStore = useGamesStore()

const filter = computed(() => gamesStore.filter)
const genres = computed(() => gamesStore.genres)

const name = computed({
  get: () => filter.value.name,
  set: (value: string) => {
    filter.value.name = value
  }
})
const genreId = computed({
  get: () => filter.value.genreId,
  set: (value: string) => {
    filter.value.genreId = tryParseInt(value)
  }
})

const updateGenre = (genreIdString: string) => {
  genreId.value = tryParseInt(genreIdString)
}
</script>

<template>
  <div class="form-container">
    <CommonInputText v-model="name" :label="$t('common.name')" />
    <CommonDropdown
      :label="$t('common.genre')"
      :modelValue="genreId as string"
      :options="genres"
      @update:modelValue="updateGenre"
    />
  </div>
</template>

<style scoped>

</style>
