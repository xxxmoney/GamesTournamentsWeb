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
  },
  flexOrientation: {
    type: String,
    default: 'col'
  }
})
</script>

<template>
  <div :class="`flex-${flexOrientation}`" class="inline-flex">
    <slot name="aboveLabel" />
    <span v-if="showLabel">{{ label }}</span>
    <slot />
  </div>
</template>
