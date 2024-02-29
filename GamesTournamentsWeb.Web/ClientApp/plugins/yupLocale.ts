import { setLocale } from 'yup'

export default defineNuxtPlugin({
  hooks: {
    'vue:setup' () {
      setLocale({
        mixed: {
          default: 'validation.invalid',
          required: 'validation.required'
        }
      })
    }
  }
})
