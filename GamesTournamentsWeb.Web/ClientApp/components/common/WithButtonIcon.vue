<script lang="ts" setup>
const { icon, severity } = defineProps({
  icon: {
    type: String,
    required: true
  },
  severity: {
    type: String,
    default: null
  },
  iconDisabled: {
    type: Boolean,
    default: false
  }
})

const emit = defineEmits(['iconClick'])

const onIconClick = () => {
  emit('iconClick')
}
</script>

<template>
  <div class="container-row items-center gap-1">
    <slot />
    <Button
      :disabled="iconDisabled"
      :icon="icon"
      :severity="severity"
      @click="onIconClick"
    />
  </div>
</template>
