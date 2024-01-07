<template>
  <div class="flex flex-row justify-between items-center">
    <div class="flex-1">
      <div class="lg:hidden">
        <LayoutDefaultMobileMenuButton />
      </div>
      <div class="hidden lg:block">
        <LayoutDefaultMainPagesLinks />
      </div>
    </div>
    <div class="flex-0">
      <CommonLogo />
    </div>
    <div class="flex-1 flex flex-row justify-end">
      <LayoutDefaultAccountControlsLinks />
    </div>
  </div>
</template>
<script lang="ts" setup>
</script>
