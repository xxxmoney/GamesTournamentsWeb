<script lang="ts" setup>
const { modelValue, label, showLabel } = defineProps({
  modelValue: {
    type: String,
    required: true
  },
  options: {
    type: Array,
    required: true
  },
  optionLabel: {
    type: String,
    default: 'name'
  },
  optionValue: {
    type: String,
    default: 'id'
  },
  label: {
    type: String,
    default: ''
  },
  showLabel: {
    type: Boolean,
    default: true
  },
  filter: {
    type: Boolean,
    default: false
  },
  showClear: {
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
    <Dropdown
      v-model="computedValue"
      :filter="filter"
      :optionLabel="optionLabel"
      :optionValue="optionValue"
      :options="options"
      :placeholder="label as string"
      :showClear="showClear"
    />
  </div>
</template>

<style>
:deep(.p-dropdown) {
  width: 100% !important;
}
</style>
