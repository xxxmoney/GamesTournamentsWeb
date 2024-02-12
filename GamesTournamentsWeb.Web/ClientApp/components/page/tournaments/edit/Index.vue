<script lang="ts" setup>
const { id } = defineProps({
  id: {
    type: Number,
    default: null
  }
})

// TODO: add to store tournament edit
</script>

<template>
  <PageTournamentsEditSteps class="w-full" />
</template>
