<script lang="ts" setup>
import type { LayoutItem } from '~/models/dashboard/LayoutItem'
import constants from '~/constants'

const store = useDashboardStore()

const layout = computed(() => store.selectedLayout)
const layoutItems = computed({
  get: () => layout.value?.items || [],
  set: (items: LayoutItem[]) => {
    layout.value!.items = items
  }
})

const emit = defineEmits(['update'])

const onLayoutUpdated = (updatedLayout: LayoutItem[]) => {
  emit('update', updatedLayout)
}
</script>

<template>
  <ClientOnly>
    <GridLayout
      :key="`layout-${layout!.id}`"
      v-model:layout="layoutItems"
      :colNum="constants.defaultLayoutMaxCols"
      :isDraggable="true"
      :isMirrored="false"
      :isResizable="true"
      :margin="[10, 10]"
      :maxRows="constants.defaultLayoutMaxRows"
      :responsive="true"
      :rowHeight="constants.defaultLayoutRowHeight"
      :useCssTransforms="true"
      :verticalCompact="true"
      @layoutUpdated="onLayoutUpdated as Function"
    >
      <GridItem
        v-for="(item, index) in layoutItems"
        :key="`layout-item-${index}`"
        :h="item.h"
        :i="index"
        :minH="constants.defaultLayoutItemHeight"
        :minW="constants.defaultLayoutItemWidth"
        :preserveAspectRatio="true"
        :w="item.w"
        :x="item.x"
        :y="item.y"
      >
        <PageDashboardModuleBase :itemId="item.id as number" :moduleId="item.moduleId as number" />
      </GridItem>
    </GridLayout>
  </ClientOnly>
</template>
