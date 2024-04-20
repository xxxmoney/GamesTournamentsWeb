<script lang="ts" setup>
const isLoggedIn = useIsLoggedIn()

// For now disable contact form
const enableContactForm = ref(false)
</script>

<template>
  <div class="inline-flex flex-col items-center mx-auto gap-y-xl">
    <PageHomeHero :showTryNow="!isLoggedIn" />
    <PageHomeFeatures />
    <PageHomeCarousel />
    <PageHomeContactForm v-if="enableContactForm && !isLoggedIn" />
  </div>
</template>
