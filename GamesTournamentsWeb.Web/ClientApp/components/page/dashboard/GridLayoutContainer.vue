<script lang="ts" setup>
import type { LayoutItem } from '~/models/dashboard/LayoutItem'

const store = useDashboardStore()

const onItemsUpdate = async (items: LayoutItem[]) => {
  await store.upsertSelectedLayoutItems(items)
}

const showSelectModuleDialog = () => {
  store.openSelectModuleModal()
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
      class="flex-1"
      @update="onItemsUpdate"
    />
  </div>
</template>
