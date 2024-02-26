<script lang="ts" setup>
const { src } = defineProps({
  src: {
    type: String,
    required: true
  }
})
</script>

<template>
  <div class="aspect-video">
    <iframe
      :src="src"
      allow="accelerometer; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share;"
      allowfullscreen
      border="0"
      class="w-full h-full"
    ></iframe>
  </div>
</template>
