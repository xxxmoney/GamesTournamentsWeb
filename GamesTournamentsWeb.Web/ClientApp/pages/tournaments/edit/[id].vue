<script lang="ts" setup>
definePageMeta({
  middleware: 'auth'
})

const route = useRoute()

const id = computed(() => Number(route.params.id))
</script>

<template>
  <PageTournamentsEdit :id="id" />
</template>
