<script lang="ts" setup>
const store = useMainStore()
const router = useRouter()

store.logout()
router.push('/')
</script>

<template>
  <div></div>
</template>
