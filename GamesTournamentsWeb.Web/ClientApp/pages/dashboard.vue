<script lang="ts" setup>
definePageMeta({
  middleware: 'auth'
})

const mainStore = useMainStore()
const dashboardStore = useDashboardStore()

const account = computed(() => mainStore.account)
const layout = computed(() => dashboardStore.selectedLayout)

if (account.value) {
  await dashboardStore.getLayouts()
}

</script>

<template>
  <div v-if="account" class="container-gap-lg w-full">
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
