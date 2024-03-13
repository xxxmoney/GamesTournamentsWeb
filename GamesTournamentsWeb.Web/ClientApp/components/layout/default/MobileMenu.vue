<script lang="ts" setup>
const visible = useMobileMenuActive()

const close = () => {
  visible.value = false
}
</script>

<template>
  <Dialog
    v-model:visible="visible"
    :header="$t('common.pages')"
    :style="{ width: '100%' }"
    modal
  >
    <div class="flex flex-row justify-between">
      <div class="flex flex-col gap-y-lg">
        <LayoutDefaultMainPagesLinks orientation="col" @linkClick="close" />
        <LayoutDefaultAccountControlsLinks bypassMobile orientation="col" @linkClick="close" />
        <LayoutDefaultOtherLinks bypassMobile orientation="col" @linkClick="close" />
      </div>
      <div>
        <CommonLogo />
      </div>
    </div>
  </Dialog>
</template>
