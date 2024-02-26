<script lang="ts" setup>
const { modelValue, label, showLabel } = defineProps({
  modelValue: {
    type: String,
    required: true
  },
  label: {
    type: String,
    default: ''
  },
  showLabel: {
    type: Boolean,
    default: true
  }
})

const emit = defineEmits(['update:modelValue'])

const computedValue = useComputedWithEmit(modelValue, emit, 'modelValue')
</script>

<template>
  <CommonWithLabel :label="label" :showLabel="showLabel">
    <Textarea
      v-model="computedValue"
      :placeholder="label as string"
      autoResize
      cols="30"
      rows="4"
    />
  </CommonWithLabel>
</template>
