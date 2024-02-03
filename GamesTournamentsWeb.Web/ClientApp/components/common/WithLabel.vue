<script lang="ts" setup>
const { label, showLabel } = defineProps({
  label: {
    type: String,
    default: ''
  },
  showLabel: {
    type: Boolean,
    default: true
  },
  containerClass: {
    type: String,
    default: ''
  }
})
</script>

<template>
  <div :class="containerClass" class="inline-flex flex-col">
    <slot name="aboveLabel" />
    <span v-if="showLabel">{{ label }}</span>
    <slot />
  </div>
</template>
