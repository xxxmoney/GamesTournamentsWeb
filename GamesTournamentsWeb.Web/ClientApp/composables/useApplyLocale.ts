import PrimeVueLocales from '~/locales/primevue/all'

const useApplyLocale = () => {
  const { setLocale } = useI18n()
  const primeVue = usePrimeVue()

  const applyLocale = (locale: string) => {
    setLocale(locale)
    // @ts-ignore
    primeVue.config.locale = PrimeVueLocales[locale]
  }

  return applyLocale
}

export { useApplyLocale }
