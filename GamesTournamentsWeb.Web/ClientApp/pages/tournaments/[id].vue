<script lang="ts" setup>
const route = useRoute()

const id = computed(() => Number(route.params.id))
</script>

<template>
  <PageTournamentsDetail :id="id" />
</template>
