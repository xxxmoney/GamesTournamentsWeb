<script lang="ts" setup>
import constants from '~/constants'
 
const store = useDashboardStore()

const isActive = computed({
  get: () => store.upsertLayoutModalActive,
  set: (value) => {
    if (!value) {
      store.closeUpsertLayoutModal()
    }
  }
})

const close = () => {
  store.closeUpsertLayoutModal()
}
</script>

<template>
  <Dialog
    v-model:visible="isActive"
    :baseZIndex="constants.dialogBaseIndexZ"
    :draggable="false"
    :header="$t('common.view')"
    :resizable="false"
    modal
  >
    <!--    TODO: add validation -->
    <div class="flex">
      <PageDashboardUpsertLayout class="mx-auto" @upserted="close" />
    </div>
  </Dialog>
</template>
