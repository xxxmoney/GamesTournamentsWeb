<script lang="ts" setup>
definePageMeta({
  middleware: 'auth'
})

const mainStore = useMainStore()
const dashboardStore = useDashboardStore()

const layout = computed(() => dashboardStore.selectedLayout)

await dashboardStore.getLayouts(mainStore.account!.id)
</script>

<template>
  <div class="container-gap-lg w-full">
    <div class="form-container-lg mx-auto items-center">
      <h1 class="heading">{{ $t('dashboard.title') }}</h1>

      <PageDashboardLayoutSelection />
    </div>

    <PageDashboardGridLayoutContainer v-if="layout" />
    <PageDashboardNoLayout v-else />

    <PageDashboardUpsertLayoutDialog />
    <PageDashboardSelectModuleDialog />
  </div>
</template>
