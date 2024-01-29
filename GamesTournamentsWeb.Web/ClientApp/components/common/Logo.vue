<script setup>
const router = useRouter()

const goToHome = () => {
  router.push('/')
}
</script>

<template>
  <img
    alt="Logo"
    class="w-16 h-16 transform cursor-pointer"
    src="/img/logo.png"
    @click="goToHome"
  />
</template>
