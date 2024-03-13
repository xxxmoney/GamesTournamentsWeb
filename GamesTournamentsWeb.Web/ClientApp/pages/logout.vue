<script lang="ts" setup>
definePageMeta({
  middleware: 'auth'
})

const store = useMainStore()
const router = useRouter()

store.logout()
router.push('/')
</script>

<template>
  <div></div>
</template>
