// https://nuxt.com/docs/api/configuration/nuxt-config

export default defineNuxtConfig({
  devtools: { enabled: true },
  modules: [
    '@nuxtjs/tailwindcss',
    'nuxt-primevue',
    '@nuxtjs/eslint-module',
    '@nuxtjs/i18n'
  ],
  css: ['~/assets/css/main.css'],
  primevue: {
    unstyled: true,
    importPT: { from: '@/presets/wind/', as: 'wind' }
  },
  i18n: {}
})
