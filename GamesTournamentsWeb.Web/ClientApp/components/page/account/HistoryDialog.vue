<script lang="ts" setup>
import constants from '~/constants'

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
    :baseZIndex="constants.dialogBaseIndexZ"
    :draggable="false"
    :header="$t('common.tournaments')"
    :resizable="false"
    modal
  >
    <div class="flex">
      <PageAccountHistory class="mx-auto" />
    </div>
  </Dialog>
</template>
