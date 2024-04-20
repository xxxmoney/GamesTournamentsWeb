<script lang="ts" setup>
import { component } from '~/enums/dashboard/component'

const successToast = useSuccessToast()
const errorToast = useErrorToast()
const store = useDashboardStore()

const { itemId } = defineProps({
  itemId: {
    type: Number,
    required: true
  }
})
const moduleId = computed(() => store.selectedLayout?.items.find(item => item.id === itemId)?.moduleId)

const resolveModule = (moduleId: number) => {
  switch (moduleId) {
    case component.tournamentHistory:
      return resolveComponent('PageDashboardModuleTournamentHistory')
    case component.winLossRatio:
      return resolveComponent('PageDashboardModuleWinLossRatio')
    default:
      throw new Error('Module not found')
  }
}
const resolvedModule = computed(() => moduleId.value ? resolveModule(moduleId.value) : null)

const showSelectModuleDialog = () => {
  store.selectedLayoutItemId = itemId
  store.openSelectModuleModal()
}
const removeLayoutItem = async () => {
  try {
    store.removeItemFromLayout(itemId)
    await store.upsertSelectedLayoutItems(store.selectedLayout!.items)
    successToast()
  } catch (e) {
    errorToast(e)
  }
}

</script>

<template>
  <div class="inline-flex flex-col px-sm gap py w-full h-full border">
    <div class="container-row-gap-sm flex-0">
      <Button
        v-tooltip="$t('common.change_module')"
        icon="pi pi-wrench"
        @click="showSelectModuleDialog"
      />
      <Button
        v-tooltip="$t('common.delete_module')"
        icon="pi pi-trash"
        severity="danger"
        @click="removeLayoutItem"
      />
    </div>

    <Component
      :is="resolvedModule"
      v-if="resolvedModule"
      :moduleId="moduleId"
      class="flex-1 overflow-auto"
    />
  </div>
</template>
