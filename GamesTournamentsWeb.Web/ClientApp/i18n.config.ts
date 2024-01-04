import en from '@/locales/en.js'
import cs from '@/locales/cs.js'

export default defineI18nConfig(() => ({
  strategy: 'prefix_and_default',
  legacy: false,
  defaultLocale: 'en',
  locales: ['en', 'cs'],
  messages: {
    en, cs
  }
}))
