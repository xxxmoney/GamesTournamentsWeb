<script lang="ts" setup>
const store = useAccountStore()

const isActive = computed({
  get: () => store.passwordChangeModalActive,
  set: (value) => {
    if (!value) {
      store.closePasswordChangeModal()
    }
  }
})

const close = () => {
  store.closePasswordChangeModal()
}
</script>

<template>
  <Dialog
    v-model:visible="isActive"
    :baseZIndex="10000"
    :draggable="false"
    :resizable="false"
    :style="{ width: '100vw' }"
    modal
  >
    <div class="flex">
      <PageAccountPasswordChange class="m-auto" @passwordChanged="close" />
    </div>
  </Dialog>
</template>
