<script lang="ts" setup>

const { options, series } = defineProps({
  options: {
    type: Object,
    required: true
  },
  series: {
    type: Array,
    required: true
  },
  type: {
    type: String,
    required: true
  }
})

</script>

<template>
  <apexchart
    :options="options"
    :series="series"
    :type="type"
  ></apexchart>
</template>
