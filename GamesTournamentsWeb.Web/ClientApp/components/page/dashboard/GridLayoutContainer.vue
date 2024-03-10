<script lang="ts" setup>
import type { LayoutItem } from '~/models/dashboard/LayoutItem'

const dashboardStore = useDashboardStore()

const layout = computed(() => dashboardStore.selectedLayout)

const onItemsUpdate = async (items: LayoutItem[]) => {
  await dashboardStore.upsertSelectedLayoutItems(items)
}

const showSelectModuleDialog = () => {
  dashboardStore.openSelectModuleModal()
}

</script>

<template>
  <div class="container-gap-lg">
    <div class="flex-0 mx-auto">
      <Button
        :label="$t('common.add_module')"
        icon="pi pi-plus"
        @click="showSelectModuleDialog"
      />
    </div>
    <PageDashboardGridLayout
      v-model:layoutItems="layout!.items"
      :layoutId="layout!.id"
      class="flex-1"
      @update="onItemsUpdate"
    />
  </div>
</template>
