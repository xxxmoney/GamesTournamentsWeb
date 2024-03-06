<script lang="ts" setup>
import { PropType } from 'vue'
import type { LayoutItem } from '~/models/dashboard/LayoutItem'
import constants from '~/constants'

const { maxRows, maxCols, layout } = defineProps({
  maxRows: {
    type: Number,
    default: constants.defaultLayoutMaxRows
  },
  maxCols: {
    type: Number,
    default: constants.defaultLayoutMaxCols
  },
  layout: {
    type: Array as PropType<LayoutItem[]>,
    default: () => []
  }
})
</script>

<template>
  <ClientOnly>
    <GridLayout :colNum="maxCols as number" :maxRows="maxRows as number">
      <GridItem
        v-for="(item, index) in layout"
        :key="`layout-item-${index}`"
        :h="item.h"
        :i="item.id"
        :w="item.w"
        :x="item.x"
        :y="item.y"
      >
        <div class="aspect-square px py">
          <component :is="item.componentName" />
        </div>
      </GridItem>
    </GridLayout>
  </ClientOnly>
</template>
