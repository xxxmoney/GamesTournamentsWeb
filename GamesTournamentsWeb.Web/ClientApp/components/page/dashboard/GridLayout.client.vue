<script lang="ts" setup>
import type { PropType } from 'vue'
import type { LayoutItem } from '~/models/dashboard/LayoutItem'
import constants from '~/constants'

const { maxRows, maxCols, layout, layoutId } = defineProps({
  maxRows: {
    type: Number,
    default: constants.defaultLayoutMaxRows
  },
  maxCols: {
    type: Number,
    default: constants.defaultLayoutMaxCols
  },
  rowHeight: {
    type: Number,
    default: constants.defaultLayoutRowHeight
  },
  layout: {
    type: Array as PropType<LayoutItem[]>,
    default: () => []
  },
  layoutId: {
    type: Number,
    required: true
  }
})

const emit = defineEmits(['update:layout', 'update'])

const layoutComputed = useComputedWithEmit(layout, emit, 'layout')
const onLayoutUpdated = (updatedLayout: Array<LayoutItem>) => {
  console.log('onLayoutUpdated', updatedLayout)
  emit('update', updatedLayout)
}
</script>

<template>
  <ClientOnly>
    <GridLayout
      :key="layoutId"
      v-model:layout="layoutComputed"
      :colNum="maxCols as number"
      :isDraggable="true"
      :isMirrored="false"
      :isResizable="true"
      :margin="[10, 10]"
      :maxRows="maxRows as number"
      :responsive="true"
      :rowHeight="rowHeight"
      :useCssTransforms="true"
      :verticalCompact="true"
      @layoutUpdated="onLayoutUpdated as Function"
    >
      <GridItem
        v-for="(module, index) in layoutComputed"
        :key="`layout-item-${index}`"
        :h="module.h"
        :i="module.i"
        :preserveAspectRatio="true"
        :w="module.w"
        :x="module.x"
        :y="module.y"
      >
        <PageDashboardModuleBase :module="module" />
      </GridItem>
    </GridLayout>
  </ClientOnly>
</template>
