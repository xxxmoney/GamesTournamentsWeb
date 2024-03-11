import PrimeVueLocales from '~/locales/primevue/all'

const useApplyLocale = () => {
  const { setLocale } = useI18n()
  const primeVue = usePrimeVue()

  const applyLocale = (locale: string) => {
    setLocale(locale)
    primeVue.config.locale = PrimeVueLocales[locale]
  }

  return applyLocale
}

export { useApplyLocale }
