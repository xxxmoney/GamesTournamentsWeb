<script lang="ts" setup>
const { icon, label } = defineProps({
  icon: {
    type: String,
    default: null
  },
  label: {
    type: String,
    default: null
  },
  severity: {
    type: String,
    default: null
  }
})

const emit = defineEmits(['click'])

const overlay = ref<HTMLElement | any | null>(null)

const onClick = (event: any) => {
  overlay.value!.toggle(event)
  emit('click')
}

</script>

<template>
  <div class="relative">
    <Button
      :icon="icon"
      :label="label"
      :severity="severity"
      @click="onClick"
    />

    <OverlayPanel ref="overlay">
      <slot />
    </OverlayPanel>
  </div>
</template>
