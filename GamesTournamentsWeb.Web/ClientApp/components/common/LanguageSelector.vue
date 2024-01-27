<script lang="ts" setup>
import constants from '~/constants'
import { KeyValuePair } from '~/models/KeyValuePair'

const mainStore = useMainStore()
const { locale, setLocale } = useI18n()
const locales = constants.locales.map(locale => new KeyValuePair(locale, locale))

const setPersistedLocale = (locale: string) => {
  setLocale(locale)
  mainStore.setLocale(locale)
}

// Set locale to i18n from persisted
setLocale(mainStore.locale)
</script>

<template>
  <Dropdown
    :modelValue="locale"
    :optionLabel="item => $t(`locales.${item.value}`)"
    :options="locales"
    class=""
    optionValue="key"
    @update:modelValue="setPersistedLocale"
  />
</template>

<style scoped>

</style>
