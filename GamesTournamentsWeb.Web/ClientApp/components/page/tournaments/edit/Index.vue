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
  <div class="container-gap">
    <PageTournamentsEditSteps />
  </div>
</template>
