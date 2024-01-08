<script lang="ts" setup>
const { modelValue, label, showLabel } = defineProps({
  modelValue: String,
  label: String,
  showLabel: {
    type: Boolean,
    default: true
  }
})

const emit = defineEmits(['update:modelValue'])

const computedValue = useComputedWithEmit(modelValue, emit, 'modelValue')
</script>

<template>
  <div class="inline-flex flex-col">
    <span v-if="showLabel">{{ label }}</span>
    <InputText v-model="computedValue" :placeholder="label as string" />
  </div>
</template>
