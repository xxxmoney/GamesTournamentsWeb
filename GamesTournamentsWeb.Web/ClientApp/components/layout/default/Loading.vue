<script lang="ts" setup>
const loading = useAllStoresLoading()
</script>

<template>
  <div
    v-if="loading"
    class="flex justify-center items-center backdrop-blur-sm absolute z-high left-0 bottom-0 right-0 top-0"
  >
    <i class="pi pi-spinner animate-spin animate-ping text-[70px] color-primary" />
  </div>
</template>
