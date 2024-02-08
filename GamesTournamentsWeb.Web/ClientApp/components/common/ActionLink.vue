<script lang="ts" setup>
const { label, labelRight, iconClass, disabled } = defineProps({
  label: {
    type: String,
    required: true
  },
  labelRight: {
    type: String,
    default: ''
  },
  iconClass: {
    type: String,
    default: 'pi pi-arrow-right'
  },
  disabled: {
    type: Boolean,
    default: false
  }
})

</script>

<template>
  <div
    :class="{'hover cursor-pointer': !disabled, 'opacity-50 cursor-not-allowed': disabled}"
    class="container-row-gap items-center color-primary"
  >
    <span v-if="label">{{ label }}</span>
    <span :class="iconClass"></span>
    <span v-if="labelRight">{{ labelRight }}</span>
  </div>
</template>
