<script lang="ts" setup>
import InputText from '~/components/common/InputText.vue'

const { modelValue, label } = defineProps({
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
    <Password
      v-model="computedValue"
      :mediumLabel="$t('password.medium')"
      :placeholder="label as string"
      :promptLabel="$t('password.prompt')"
      :strongLabel="$t('password.strong')"
      :weakLabel="$t('password.weak')"
      inputClass="w-full"
    />
  </CommonWithLabel>
</template>
