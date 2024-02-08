<script lang="ts" setup>
const { icon, severity } = defineProps({
  icon: {
    type: String,
    required: true
  },
  severity: {
    type: String,
    default: 'secondary'
  }
})

const emit = defineEmits(['iconClick'])

const onIconClick = () => {
  emit('iconClick')
}
</script>

<template>
  <div class="container-row gap-1">
    <slot />
    <Button :icon="icon" :severity="severity" @click="onIconClick" />
  </div>
</template>
