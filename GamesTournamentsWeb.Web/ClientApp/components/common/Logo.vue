<script setup>
const router = useRouter()

const goToHome = () => {
  router.push('/')
}
</script>

<template>
  <img
    alt="Logo"
    class="w-16 h-16 transform -translate-x-1 cursor-pointer"
    src="/logo.png"
    @click="goToHome"
  >
</template>
