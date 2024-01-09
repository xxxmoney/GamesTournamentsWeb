<script lang="ts" setup>
const { modelValue, label } = defineProps({
  modelValue: {
    type: String,
    required: true
  },
  label: {
    type: String,
    default: ''
  }
})

const emit = defineEmits(['update:modelValue'])

const computedValue = useComputedWithEmit(modelValue, emit, 'modelValue')
</script>

<template>
  <div class="inline-flex flex-col">
    <span>{{ label }}</span>
    <Password
      v-model="computedValue"
      :mediumLabel="$t('password.medium')"
      :placeholder="label as string"
      :promptLabel="$t('password.prompt')"
      :strongLabel="$t('password.strong')"
      :weakLabel="$t('password.weak')"
      inputClass="w-full"
    />
  </div>
</template>
