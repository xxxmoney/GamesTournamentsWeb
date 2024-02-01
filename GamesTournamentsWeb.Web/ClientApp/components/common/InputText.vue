<script lang="ts" setup>
const { modelValue, label, showLabel, inputClass } = defineProps({
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
  },
  inputClass: {
    type: String,
    default: ''
  }
})

const emit = defineEmits(['update:modelValue'])

const computedValue = useComputedWithEmit(modelValue, emit, 'modelValue')
</script>

<template>
  <CommonWithLabel :label="label" :showLabel="showLabel">
    <InputText v-model="computedValue" :class="inputClass" :placeholder="label as string" />
  </CommonWithLabel>
</template>
