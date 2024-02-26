<script lang="ts" setup>
import constants from '~/constants'

const { imageUrl, label } = defineProps({
  imageUrl: {
    type: String,
    required: true
  },
  label: {
    type: String,
    default: null
  },
  pointer: {
    type: Boolean,
    default: false
  },
  width: {
    type: String,
    default: 'w-16'
  }
})

const imageUrlComputed = computed(() => imageUrl ?? constants.defaultProfileImageUrl)

const emit = defineEmits(['click'])

const emitClick = () => {
  emit('click')
}
</script>

<template>
  <div
    :class="{'hover cursor-pointer': pointer}"
    class="form-container"
  >
    <img
      :class="width"
      :src="imageUrlComputed"
      alt="Image"
      class="object-cover rounded-full aspect-square"
      @click="emitClick"
    />

    <span class="">{{ label }}</span>
  </div>
</template>
