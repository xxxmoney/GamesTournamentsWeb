<script lang="ts" setup>
const dashboardStore = useDashboardStore()

const selectedLayoutId = computed({
  get: () => dashboardStore.selectedLayoutId,
  set: (value) => {
    dashboardStore.selectedLayoutId = value
  }
})
const selectedLayout = computed(() => dashboardStore.selectedLayout)
const isSelectedLayout = computed(() => !!dashboardStore.selectedLayoutId)
const layouts = computed(() => dashboardStore.layouts)

const saveItems = async () => {
  await dashboardStore.upsertSelectedLayoutItems(selectedLayout.value!.items)
}

const removeSelectedLayout = async () => {
  await dashboardStore.removeLayout(selectedLayout.value!.id)
}

const showCreateLayoutDialog = () => {
  dashboardStore.openUpsertLayoutModal()
}
const showUpdateLayoutDialog = () => {
  dashboardStore.setCurrentLayoutAsUpsert()
  dashboardStore.openUpsertLayoutModal()
}

</script>

<template>
  <div class="container-gap">
    <CommonWithLabel :label="$t('common.choose_view')">
      <CommonWithButtonIcon
        v-tooltip="$t('common.delete')"
        :iconDisabled="!isSelectedLayout"
        icon="pi pi-trash"
        severity="danger"
        @iconClick="removeSelectedLayout"
      >
        <CommonWithButtonIcon
          v-tooltip="$t('common.save')"
          :iconDisabled="!isSelectedLayout"
          icon="pi pi-save"
          @iconClick="saveItems"
        >
          <CommonWithButtonIcon
            v-tooltip="$t('common.update_view')"
            :iconDisabled="!isSelectedLayout"
            icon="pi pi-file-edit"
            @iconClick="showUpdateLayoutDialog"
          >
            <CommonWithButtonIcon
              v-tooltip="$t('common.add_view')"
              icon="pi pi-plus"
              @iconClick="showCreateLayoutDialog"
            >
              <Dropdown
                v-model:modelValue="selectedLayoutId"
                :options="layouts"
                :placeholder="$t('common.choose_view')"
                filter
                optionLabel="name"
                optionValue="id"
                showClear
              />
            </CommonWithButtonIcon>
          </CommonWithButtonIcon>
        </CommonWithButtonIcon>
      </CommonWithButtonIcon>
    </CommonWithLabel>
  </div>
</template>

<style scoped>

</style>
