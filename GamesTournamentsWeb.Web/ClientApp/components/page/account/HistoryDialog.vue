<script lang="ts" setup>
const store = useAccountStore()

const isActive = computed({
  get: () => store.historyModalActive,
  set: (value) => {
    if (!value) {
      store.closeHistoryModal()
    }
  }
})

</script>

<template>
  <Dialog
    v-model:visible="isActive"
    :baseZIndex="10000"
    :draggable="false"
    :header="$t('common.tournaments')"
    :resizable="false"
    modal
  >
    <div class="flex">
      <PageAccountHistory class="m-auto" />
    </div>
  </Dialog>
</template>
