<script lang="ts" setup>
const { label, showLabel } = defineProps({
  label: {
    type: String,
    default: ''
  },
  showLabel: {
    type: Boolean,
    default: true
  }
})
</script>

<template>
  <div class="container">
    <span v-if="showLabel">{{ label }}</span>
    <slot />
  </div>
</template>
