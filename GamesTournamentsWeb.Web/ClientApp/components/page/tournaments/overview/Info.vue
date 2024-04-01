<script lang="ts" setup>
const { name, gameName, regionNames, platformName, startDate, endDate } = defineProps({
  name: {
    type: String,
    required: true
  },
  gameName: {
    type: String,
    required: true
  },
  regionNames: {
    type: Array<String>,
    required: true
  },
  platformName: {
    type: String,
    required: true
  },
  startDate: {
    type: Date,
    required: true
  },
  endDate: {
    type: Date,
    required: false
  }
})

const startDateClass = computed(() => {
  if (endDate) {
    return 'text-gray-400'
  }

  const nowUtc = new Date().getUTCDate()
  return new Date(startDate).getUTCDate() > nowUtc ? 'color-primary animate-pulse' : ''
})
</script>

<template>
  <h2 class="subheading mt">{{ name }}</h2>

  <div class="inline-flex flex-row gap">
    <span class="italic">{{ gameName }}</span>
    <span class="italic">{{ joinWithComma(regionNames) }}</span>
    <span class="italic">{{ platformName }}</span>
  </div>

  <div class="container gap">
    <span :class="startDateClass">{{ formatJsDate(startDate) }}</span>

    <div v-if="!endDate">
      <span>{{ $t('common.starts_in') }}: {{ timeDifferenceJs(startDate) }}</span>
    </div>
    <div v-else>
      <span v-tooltip="formatJsDate(endDate)">{{ $t('common.has_ended') }}</span>
    </div>
  </div>
</template>
