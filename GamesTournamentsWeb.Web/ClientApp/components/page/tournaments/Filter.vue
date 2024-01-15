<script lang="ts" setup>
const tournamentsStore = useTournamentsStore()

const filter = computed(() => tournamentsStore.filter)
</script>

<template>
  <div class="form-container">
    <CommonInputText v-model="filter.name" :label="$t('common.name')" />

    <CommonWithLabel :label="$t('common.my_tournaments')">
      <Checkbox v-model="filter.withMyTournaments" :binary="true" />
    </CommonWithLabel>
  </div>
</template>
