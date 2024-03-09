<script lang="ts" setup>
import type { LayoutItem } from '~/models/dashboard/LayoutItem'

const dashboardStore = useDashboardStore()

const layout = computed(() => dashboardStore.selectedLayout)

const onItemsUpdate = async (items: LayoutItem[]) => {
  await dashboardStore.updateLayoutItems(items)
}

</script>

<template>
  <PageDashboardGridLayout
    v-if="layout"
    v-model:layoutItems="layout.items"
    :layoutId="layout.id"
    @update="onItemsUpdate"
  />
</template>
