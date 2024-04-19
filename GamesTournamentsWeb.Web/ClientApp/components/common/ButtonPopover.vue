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

const emit = defineEmits(['click', 'show', 'hide'])

const overlay = ref<HTMLElement | any | null>(null)

const onClick = (event: any) => {
  overlay.value!.toggle(event)
  emit('click')
}

const toggle = () => {
  overlay.value!.toggle()
}

const onShow = () => {
  emit('show')
}

const onHide = () => {
  emit('hide')
}

defineExpose({
  toggle
})

</script>

<template>
  <div class="relative inline popover">
    <Button
      :icon="icon"
      :label="label"
      :severity="severity"
      @click="onClick"
    />

    <OverlayPanel ref="overlay" @hide="onHide" @show="onShow">
      <slot />
    </OverlayPanel>
  </div>
</template>
