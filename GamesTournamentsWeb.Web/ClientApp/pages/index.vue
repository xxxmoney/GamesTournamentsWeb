<script lang="ts" setup>
const isLoggedIn = useIsLoggedIn()
</script>

<template>
  <div class="inline-flex flex-col items-center mx-auto gap-y-xl">
    <PageHomeHero :showTryNow="!isLoggedIn" />
    <PageHomeFeatures />
    <PageHomeCarousel />
    <PageHomeContactForm v-if="!isLoggedIn" />
  </div>
</template>
