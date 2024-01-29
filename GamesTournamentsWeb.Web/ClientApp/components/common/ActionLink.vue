<script lang="ts" setup>
const { label } = defineProps({
  label: {
    type: String,
    required: true
  }
})

const emit = defineEmits(['click'])

const onClick = () => {
  emit('click')
}
</script>

<template>
  <div class="container-row-gap items-center color-primary hover cursor-pointer" @click="onClick">
    <span>{{ label }}</span>
    <span class="pi pi-arrow-right"></span>
  </div>
</template>
