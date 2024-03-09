<script lang="ts" setup>
const dashboardStore = useDashboardStore()

const layout = computed(() => dashboardStore.selectedLayout)

//await dashboardStore.getLayouts(mainStore.account!.id)
</script>

<template>
  <div class="inline-flex flex-col w-full">
    <div class="form-container-lg mx-auto items-center">
      <h1 class="heading">{{ $t('dashboard.title') }}</h1>

      <PageDashboardLayoutSelection />
    </div>

    <PageDashboardGridLayoutContainer v-if="layout" />
    <PageDashboardNoLayout v-else />

    <PageDashboardUpsertLayoutDialog />
  </div>
</template>
