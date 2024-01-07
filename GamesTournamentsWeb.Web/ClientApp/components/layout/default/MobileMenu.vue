<script lang="ts" setup>
const visible = useMobileMenuActive()
</script>

<template>
  <Dialog
    v-model:visible="visible"
    :header="$t('common.pages')"
    :style="{ width: '100%' }"
    modal
  >
    <div class="flex flex-row justify-between">
      <div class="flex flex-col gap-y-double">
        <LayoutDefaultMainPagesLinks orientation="col" />
        <LayoutDefaultAccountControlsLinks bypassMobile orientation="col" />
        <LayoutDefaultOtherLinks bypassMobile orientation="col" />
      </div>
      <div>
        <CommonLogo />
      </div>
    </div>
  </Dialog>
</template>
