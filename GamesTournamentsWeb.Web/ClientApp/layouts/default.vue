<script lang="ts" setup>

</script>

<template>
  <div class="flex flex-col h-full">
    <header class="flex-grow-0 sticky top-0">
      <LayoutDefaultHeader />
    </header>

    <main class="active-area relative flex-1 my-4 lg:my-16 flex col">
      <slot />
    </main>

    <footer class="flex-grow-0">
      <LayoutDefaultFooter />
    </footer>
  </div>

  <LayoutDefaultMobileMenu />
</template>

<style scoped>

</style>
