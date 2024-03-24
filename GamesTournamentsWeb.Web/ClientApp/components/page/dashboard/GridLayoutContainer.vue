<script lang="ts" setup>
const store = useDashboardStore()

const showSelectModuleDialog = () => {
  store.openSelectModuleModal()
}

</script>

<template>
  <div class="container-gap-lg">
    <div class="flex-0 mx-auto inline-flex gap">
      <Button
        :label="$t('common.add_module')"
        icon="pi pi-plus"
        @click="showSelectModuleDialog"
      />
    </div>
    <PageDashboardGridLayout
      class="flex-1"
    />
  </div>
</template>
