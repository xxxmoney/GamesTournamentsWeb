<script lang="ts" setup>

const { modelValue, label, showLabel, invalid } = defineProps({
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
  invalid: {
    type: Boolean,
    default: false
  }
})

const emit = defineEmits(['update:modelValue'])

const computedValue = useComputedWithEmit(modelValue, emit, 'modelValue')
</script>

<template>
  <CommonWithLabel :label="label" :showLabel="showLabel">
    <Password
      v-model="computedValue"
      :invalid="invalid"
      :mediumLabel="$t('password.medium')"
      :placeholder="label as string"
      :promptLabel="$t('password.prompt')"
      :strongLabel="$t('password.strong')"
      :weakLabel="$t('password.weak')"
      inputClass="w-full"
      toggleMask
    />
  </CommonWithLabel>
</template>
