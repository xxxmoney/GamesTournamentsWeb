<script lang="ts" setup>
const { orientation } = defineProps({
  orientation: useFlexByOrientationPropsParam()
})

const containerClass = useFlexByOrientationClass(orientation)
</script>

<template>
  <ul :class="containerClass" class="ul-links invisible lg:visible">
    <li>
      <NuxtLink to="/about">
        {{ $t('pages.about') }}
      </NuxtLink>
    </li>
    <li>
      <NuxtLink to="/contact">
        {{ $t('pages.contact') }}
      </NuxtLink>
    </li>
    <li>
      <NuxtLink to="/privacy">
        {{ $t('pages.privacy') }}
      </NuxtLink>
    </li>
    <li>
      <NuxtLink to="/terms">
        {{ $t('pages.terms') }}
      </NuxtLink>
    </li>
  </ul>
</template>
