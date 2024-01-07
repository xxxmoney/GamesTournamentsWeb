<script lang="ts" setup>
const { orientation } = defineProps({
  orientation: useFlexByOrientationPropsParam()
})

const containerClass = useFlexByOrientationClass(orientation)

const isLoggedIn = useIsLoggedIn()
</script>

<template>
  <ul :class="containerClass" class="ul-links">
    <li>
      <NuxtLink to="/">
        {{ $t('pages.home') }}
      </NuxtLink>
    </li>
    <li>
      <NuxtLink to="/tournaments">
        {{ $t('pages.tournaments') }}
      </NuxtLink>
    </li>
    <li>
      <NuxtLink to="/games">
        {{ $t('pages.games') }}
      </NuxtLink>
    </li>
    <li>
      <NuxtLink v-if="isLoggedIn" to="/dashboard">
        {{ $t('pages.dashboard') }}
      </NuxtLink>
    </li>
  </ul>
</template>

<style scoped>

</style>
