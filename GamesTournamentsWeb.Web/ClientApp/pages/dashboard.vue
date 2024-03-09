<script lang="ts" setup>
import type { LayoutItem } from '~/models/dashboard/LayoutItem'

const dashboardStore = useDashboardStore()
const mainStore = useMainStore()

const layout = computed(() => dashboardStore.selectedLayout)

const onItemsUpdate = async (items: LayoutItem[]) => {
  await dashboardStore.updateLayoutItems(items)
}

const showCreateLayoutDialog = () => {
  dashboardStore.openUpsertLayoutModal()
}

//await dashboardStore.getLayouts(mainStore.account!.id)
</script>

<template>
  <div class="inline-flex flex-col w-full">
    <div class="form-container-lg mx-auto items-center">
      <h1 class="heading">{{ $t('dashboard.title') }}</h1>
    </div>

    <PageDashboardGridLayout
      v-if="layout"
      v-model:layoutItems="layout.items"
      :layoutId="layout.id"
      @update="onItemsUpdate"
    />
    <PageDashboardNoLayout v-else />

    <PageDashboardUpsertLayoutDialog />
  </div>
</template>
