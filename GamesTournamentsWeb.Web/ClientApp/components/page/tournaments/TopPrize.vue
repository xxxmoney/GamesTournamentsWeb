<script lang="ts" setup>
const { amount, currencySymbol } = defineProps({
  amount: {
    type: Number,
    required: true
  },
  currencySymbol: {
    type: String,
    required: true
  },
  colorClass: {
    type: String,
    default: ''
  }
})
</script>

<template>
  <CommonWithLabel
    :label="`${amount} ${currencySymbol}`"
    containerClass="items-center"
  >
    <template #aboveLabel>
      <font-awesome-icon :class="colorClass" :icon="['fas', 'trophy']" class=" text-6xl" />
    </template>
  </CommonWithLabel>
</template>
