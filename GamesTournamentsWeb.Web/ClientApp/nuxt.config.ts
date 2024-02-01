// https://nuxt.com/docs/api/configuration/nuxt-config

export default defineNuxtConfig({
  experimental: {
    renderJsonPayloads: true
  },
  devtools: { enabled: false },
  modules: [
    '@nuxtjs/tailwindcss',
    'nuxt-primevue',
    '@nuxtjs/eslint-module',
    '@nuxtjs/i18n',
    '@pinia/nuxt'
  ],
  css: ['~/assets/css/main.css', 'primeicons/primeicons.css', '@fortawesome/fontawesome-svg-core/styles.css'],
  primevue: {
    unstyled: true,
    importPT: { from: '@/presets/wind/', as: 'wind' }
  },
  i18n: {},
  pinia: {
    storesDirs: ['./stores/**']
  },
  image: {
    domains: ['your-domain.com']
  }
})
