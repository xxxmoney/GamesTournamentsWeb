<script setup>
const { size, icon, iconType } = defineProps({
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
  }
})

const iconClass = computed(() => {
  return `text-${size} text-black ${iconType} ${icon}`
})

</script>

<template>
  <i :class="iconClass" class="cursor-pointer"></i>
</template>
