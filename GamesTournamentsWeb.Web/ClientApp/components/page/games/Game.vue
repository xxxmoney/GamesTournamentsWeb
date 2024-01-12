<script lang="ts" setup>
const { id, name } = defineProps({
  id: {
    type: Number,
    required: true
  },
  name: {
    type: String,
    required: true
  }
})

</script>

<template>
  <div class="">
    <span>{{ id }}</span>
    <span>{{ name }}</span>
  </div>
</template>
