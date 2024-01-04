import en from '@/locales/en.js'
import cs from '@/locales/cs.js'

export default defineI18nConfig(() => ({
  legacy: false,
  locale: 'en',
  messages: {
    en, cs
  }
}))
