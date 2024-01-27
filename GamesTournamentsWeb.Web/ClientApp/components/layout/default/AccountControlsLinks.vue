<script setup>

const { orientation, bypassMobile } = defineProps({
  orientation: useFlexByOrientationPropsParam(),
  bypassMobile: {
    type: Boolean,
    default: false
  }
})

const isLoggedIn = useIsLoggedIn()

const containerClass = useFlexByOrientationClass(orientation)

const mobileClass = computed(() => bypassMobile ? '' : 'hidden lg:block')
</script>

<template>
  <ul :class="containerClass" class="ul-links">
    <li v-if="!isLoggedIn">
      <NuxtLink to="/login">
        {{ $t('pages.login') }}
      </NuxtLink>
    </li>
    <li v-if="!isLoggedIn" :class="mobileClass">
      <NuxtLink to="/register">
        {{ $t('pages.register') }}
      </NuxtLink>
    </li>
    <li v-if="isLoggedIn">
      <NuxtLink to="/account">
        {{ $t('pages.account') }}
      </NuxtLink>
    </li>
    <li v-if="isLoggedIn" :class="mobileClass">
      <NuxtLink to="/logout">
        {{ $t('pages.logout') }}
      </NuxtLink>
    </li>
    <li :class="mobileClass">
      <Divider class="md:hidden" />
      <CommonLanguageSelector />
      <Divider class="md:hidden" />
    </li>
  </ul>
</template>
