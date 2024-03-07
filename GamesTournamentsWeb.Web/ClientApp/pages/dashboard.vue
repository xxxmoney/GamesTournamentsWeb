<script lang="ts" setup>
const store = useDashboardStore()

const layout = computed({
  get: () => store.layout,
  set: (value) => {
    store.layout = value
  }
})

await store.getLayout()
</script>

<template>
  <div class="w-full">
    <div class="form-container-lg mx-auto">
    </div>

    <PageDashboardGridLayout v-model:layout="layout" />
  </div>
</template>
