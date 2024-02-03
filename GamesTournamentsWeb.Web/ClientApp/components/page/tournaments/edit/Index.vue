<script lang="ts" setup>
const { id } = defineProps({
  id: {
    type: Number,
    required: true
  }
})
</script>

<template>
  <div class="container-gap">
    <PageTournamentsEditSteps />
  </div>
</template>
