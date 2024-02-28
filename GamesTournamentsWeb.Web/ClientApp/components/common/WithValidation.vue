<script lang="ts" setup>
const props = defineProps({
  errorMessage: {
    required: true
  }
})
</script>

<template>
  <div class="container-gap">
    <slot></slot>
    <small class="text-red-300">{{ errorMessage }}</small>
  </div>
</template>
