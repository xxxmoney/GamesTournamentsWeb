<script lang="ts" setup>
const { orientation, bypassMobile } = defineProps({
  orientation: useFlexByOrientationPropsParam(),
  bypassMobile: {
    type: Boolean,
    default: false
  }
})

const emit = defineEmits(['linkClick'])
const onLinkClick = () => {
  emit('linkClick')
}

const flexClass = useFlexByOrientationClass(orientation)
const mobileClass = computed(() => bypassMobile ? '' : 'invisible lg:visible')

const containerClass = computed(() => {
  return [
    flexClass.value,
    mobileClass.value
  ].join(' ')
})
</script>

<template>
  <ul :class="containerClass" class="ul-links">
    <li>
      <NuxtLink to="/about" @click="onLinkClick">
        {{ $t('pages.about') }}
      </NuxtLink>
    </li>
    <li>
      <NuxtLink to="/contact" @click="onLinkClick">
        {{ $t('pages.contact') }}
      </NuxtLink>
    </li>
    <li>
      <NuxtLink to="/privacy" @click="onLinkClick">
        {{ $t('pages.privacy') }}
      </NuxtLink>
    </li>
    <li>
      <NuxtLink to="/terms" @click="onLinkClick">
        {{ $t('pages.terms') }}
      </NuxtLink>
    </li>
  </ul>
</template>
