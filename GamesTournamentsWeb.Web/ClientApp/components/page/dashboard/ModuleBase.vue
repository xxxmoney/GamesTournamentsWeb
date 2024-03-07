<script lang="ts" setup>
import type { PropType } from 'vue'
import type { LayoutItem } from '~/models/dashboard/LayoutItem'

const { module } = defineProps({
  module: {
    type: Object as PropType<LayoutItem>,
    required: true
  }
})
</script>

<template>
  <div class="inline-flex flex-col px py">
    <div class="flex-0"></div>

    <component :is="module!.componentName" class="flex-1" />
  </div>
</template>
