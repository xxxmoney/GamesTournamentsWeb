<script lang="ts" setup>
const { modelValue, label } = defineProps({
  modelValue: String,
  label: String
})

const emit = defineEmits(['update:modelValue'])

const computedValue = useComputedWithEmit(modelValue, emit, 'modelValue')
</script>

<template>
  <div class="inline-flex flex-col">
    <span>{{ label }}</span>
    <InputText v-model="computedValue" :placeholder="label as string" />
  </div>
</template>
