<script lang="ts" setup>
const mobileMenuActive = useMobileMenuActive()

const showMenu = () => {
  mobileMenuActive.value = true
}
</script>

<template>
  <CommonIcon
    class="cursor-pointer"
    icon="pi-align-justify"
    size="2xl"
    @click="showMenu"
  />
</template>
