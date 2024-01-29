<script lang="ts" setup>
const { name, gameName, regionName, platformName, startDate } = defineProps({
  name: {
    type: String,
    required: true
  },
  gameName: {
    type: String,
    required: true
  },
  regionName: {
    type: String,
    required: true
  },
  platformName: {
    type: String,
    required: true
  },
  startDate: {
    type: Date,
    required: true
  }
})
</script>

<template>
  <h2 class="subheading mt">{{ name }}</h2>

  <div class="inline-flex flex-row gap">
    <span class="italic">{{ gameName }}</span>
    <span class="italic">{{ regionName }}</span>
    <span class="italic">{{ platformName }}</span>
  </div>

  <div class="container gap">
    <span>{{ formatJsDate(startDate) }}</span>
    <span>{{ $t('common.starts_in') }}: {{ timeDifferenceJs(startDate) }}</span>
  </div>
</template>

<style scoped>

</style>
