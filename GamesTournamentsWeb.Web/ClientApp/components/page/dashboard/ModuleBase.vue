<script lang="ts" setup>
import type { ConcreteComponent } from 'vue'
import { component } from '~/enums/dashboard/component'

const store = useDashboardStore()

const { itemId } = defineProps({
  itemId: {
    type: Number,
    required: true
  }
})
const moduleId = computed(() => store.selectedLayout!.items.find(item => item.id === itemId)!.moduleId)

const resolveModule = (moduleId: number) => {
  switch (moduleId) {
    case component.default:
      return resolveComponent('PageDashboardModuleDefault')
    default:
      throw new Error('Module not found')
  }
}
const resolvedModule = computed(() => resolveModule(moduleId.value))

const showSelectModuleDialog = () => {
  store.selectedLayoutItemId = itemId
  store.openSelectModuleModal()
}
const removeLayoutItem = () => {
  store.removeItemFromLayout(itemId)
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

    <Component :is="resolvedModule" class="flex-1" />
  </div>
</template>
