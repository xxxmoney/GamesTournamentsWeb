<script lang="ts" setup>
const { icon, severity, iconDisabled, iconClass } = defineProps({
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
  },
  iconClass: {
    type: Object,
    default: null
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
      :class="iconClass"
      :disabled="iconDisabled as Boolean"
      :icon="icon"
      :severity="severity"
      @click="onIconClick"
    />
  </div>
</template>
