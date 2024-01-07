<script lang="ts" setup>
const { modelValue, label } = defineProps({
  modelValue: String,
  label: String
})

const emit = defineEmits(['update:modelValue'])

const computedValue = useComputedWithEmit(modelValue, emit, 'modelValue')
</script>

<template>
  <Password
    v-model="computedValue"
    :mediumLabel="$t('password.medium')"
    :placeholder="label as string"
    :promptLabel="$t('password.prompt')"
    :weakLabel="$t('password.weak')"
    s:trongLabel="$t('password.strong')"
  />
</template>
