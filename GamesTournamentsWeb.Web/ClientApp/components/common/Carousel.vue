<script lang="ts" setup>
const { images } = defineProps({
  images: {
    type: Array<string>,
    required: true
  }
})

const getNextIndex = (index: number) => {
  if (index === images.length - 1) {
    return 0
  }
  return index + 1
}
const getPreviousIndex = (index: number) => {
  if (index === 0) {
    return images.length - 1
  }
  return index - 1
}
</script>

<template>
  <div class="carousel rounded-xl shadow-2xl w-full">
    <div
      v-for="(image, index) in images"
      :id="`slide${index}`"
      :key="`carousel-image-${index}`"
      class="carousel-item relative w-full"
    >
      <img :src="image" class="w-full" />
      <div class="absolute flex justify-between transform -translate-y-1/2 left-5 right-5 top-1/2">
        <a :href="`#slide${getPreviousIndex(index)}`" class="btn btn-circle">❮</a>
        <a :href="`#slide${getNextIndex(index)}`" class="btn btn-circle">❯</a>
      </div>
    </div>
  </div>
</template>
