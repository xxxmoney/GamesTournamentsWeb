<script lang="ts" setup>
const { imageUrl } = defineProps({
  imageUrl: {
    type: String,
    required: true
  }
})

const emit = defineEmits(['click'])

const emitClick = () => {
  emit('click')
}
</script>

<template>
  <div
    class="form-container relative aspect-card overflow-hidden"
  >
    <img
      :src="imageUrl as string"
      alt="Image"
      class="object-cover w-full h-full rounded-xl hover cursor-pointer"
      @click="emitClick"
    />

    <slot />
  </div>
</template>
