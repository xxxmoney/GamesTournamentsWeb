<script setup>
const { size, icon, iconType, cursor } = defineProps({
  size: {
    type: String,
    default: 'md'
  },
  icon: {
    type: String,
    required: true
  },
  iconType: {
    type: String,
    default: 'pi'
  },
  cursor: {
    type: Boolean,
    default: false
  }
})

const iconClass = computed(() => {
  return `text-${size} text-black ${iconType} ${icon} ${cursor ? 'cursor-pointer' : ''}`
})

</script>

<template>
  <i :class="iconClass"></i>
</template>
