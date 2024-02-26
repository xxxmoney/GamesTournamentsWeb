<script lang="ts" setup>
const { header } = defineProps({
  header: {
    type: String,
    required: true
  }
})
</script>

<template>
  <Panel :collapsed="false" :header="header as string" toggleable>
    <slot />
  </Panel>
</template>
