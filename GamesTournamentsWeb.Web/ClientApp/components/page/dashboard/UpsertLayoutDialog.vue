<script lang="ts" setup>
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
    :baseZIndex="10000"
    :draggable="false"
    :header="$t('dashboard.new_view')"
    :resizable="false"
    modal
  >
    <!--    TODO: add validation -->
    <div class="flex">
      <PageDashboardUpsertLayout class="mx-auto" @upserted="close" />
    </div>
  </Dialog>
</template>
