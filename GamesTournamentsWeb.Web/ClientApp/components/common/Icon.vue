<script setup>
const { size, icon } = defineProps({
  size: {
    type: String,
    default: 'md'
  },
  icon: {
    type: String,
    required: true
  }
})

const iconClass = computed(() => {
  return `text-${size} text-black pi ${icon}`
})
</script>

<template>
  <i :class="iconClass"></i>
</template>
