<script lang="ts" setup>
const store = useDashboardStore()

const layout = computed(() => store.layout)

await store.getLayout()
</script>

<template>
  <div class="form-container-lg mx-auto">
    <PageDashboardGridLayout :layout="layout" />
  </div>
</template>
