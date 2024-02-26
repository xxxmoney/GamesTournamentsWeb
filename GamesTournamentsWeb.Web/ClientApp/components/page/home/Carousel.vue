<script lang="ts" setup>
import constants from '~/constants'

const path = '/img/game/'
const images = constants.carouselImages.map(image => `${path}${image}`)
</script>

<template>
  <CommonCarousel :images="images" class="max-w-2xl" />
</template>
