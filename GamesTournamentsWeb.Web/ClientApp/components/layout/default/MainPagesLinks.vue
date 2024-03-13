<script lang="ts" setup>
const { orientation } = defineProps({
  orientation: useFlexByOrientationPropsParam()
})

const emit = defineEmits(['linkClick'])
const onLinkClick = () => {
  emit('linkClick')
}

const containerClass = useFlexByOrientationClass(orientation)

const isLoggedIn = useIsLoggedIn()
</script>

<template>
  <ul :class="containerClass" class="ul-links">
    <li>
      <NuxtLink to="/" @click="onLinkClick">
        {{ $t('pages.home') }}
      </NuxtLink>
    </li>
    <li>
      <NuxtLink to="/tournaments" @click="onLinkClick">
        {{ $t('pages.tournaments') }}
      </NuxtLink>
    </li>
    <li>
      <NuxtLink to="/games" @click="onLinkClick">
        {{ $t('pages.games') }}
      </NuxtLink>
    </li>
    <li v-if="isLoggedIn">
      <NuxtLink to="/dashboard" @click="onLinkClick">
        {{ $t('pages.dashboard') }}
      </NuxtLink>
    </li>
  </ul>
</template>

<style scoped>

</style>
