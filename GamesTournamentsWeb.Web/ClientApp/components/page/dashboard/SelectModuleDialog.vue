<script lang="ts" setup>
import constants from '~/constants'

const store = useDashboardStore()

const isActive = computed({
  get: () => store.selectModuleModalActive,
  set: (value) => {
    if (!value) {
      store.closeSelectModuleModal()
    }
  }
})

const close = () => {
  store.closeSelectModuleModal()
}
</script>

<template>
  <Dialog
    v-model:visible="isActive"
    :baseZIndex="constants.dialogBaseIndexZ"
    :draggable="false"
    :header="$t('common.module')"
    :resizable="false"
    modal
  >
    <!--    TODO: add validation -->
    <div class="flex">
      <PageDashboardSelectModule class="mx-auto" @selected="close" />
    </div>
  </Dialog>
</template>
