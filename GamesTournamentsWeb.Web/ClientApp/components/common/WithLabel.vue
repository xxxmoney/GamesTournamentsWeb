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
  <div class="inline-flex flex-col">
    <span v-if="showLabel">{{ label }}</span>
    <slot />
  </div>
</template>
