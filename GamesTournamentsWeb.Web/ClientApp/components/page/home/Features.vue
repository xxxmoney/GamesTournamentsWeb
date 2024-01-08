<script setup>
import constants from '~/constants.ts'

</script>

<template>
  <div>
    <div v-for="feature in constants.features" :key="`feature-${feature}`" class="form-container items-center mb">
      <div class="p-3 rounded-full bg-blue-100">
        <CommonIcon class="color-primary" icon="pi-star" size="2xl" />
      </div>

      <h2 class="subheading">{{ $t(`home.features.${feature}.title`) }}</h2>
      <p class="text-center">{{ $t(`home.features.${feature}.description`) }}</p>
    </div>
  </div>
</template>
