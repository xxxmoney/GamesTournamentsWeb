<script lang="ts" setup>
import constants from '~/constants'
import { KeyValuePair } from '~/models/KeyValuePair'

const mainStore = useMainStore()
const { locale } = useI18n()
const applyLocale = useApplyLocale()

const locales = constants.locales.map(locale => new KeyValuePair(locale, locale))

const setPersistedLocale = (locale: string) => {
  mainStore.setLocale(locale)

  applyLocale(locale)
}

// Set locale from persisted
applyLocale(mainStore.locale)
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
