<script lang="ts" setup>
const store = useDashboardStore()
const successToast = useSuccessToast()
const errorToast = useErrorToast()

const selectedModuleId = ref<number | null>(null)
const modules = computed(() => store.modules)

const emit = defineEmits(['selected'])

const selectModule = async () => {
  if (!selectedModuleId.value) {
    throw new Error('Module Id is not selected')
  }
  
  try {
    store.updateOrAddSelectedLayoutItem(selectedModuleId.value)
    await store.upsertSelectedLayoutItems(store.selectedLayout!.items)
    emit('selected', selectedModuleId.value)

    successToast()
  } catch (e) {
    errorToast(e)
  }
}
</script>

<template>
  <div class="form-container mx-auto">
    <CommonWithLabel :label="$t('common.choose_module')">
      <Dropdown
        v-model:modelValue="selectedModuleId"
        :optionLabel="value => $t(`dashboard.modules.${toSnakeCase(value.name)}.title`)"
        :options="modules"
        :placeholder="$t('common.choose_module')"
        optionValue="id"
        showClear
      />
    </CommonWithLabel>

    <Button
      :disabled="!selectedModuleId"
      :label="$t('common.select')"
      icon="pi pi-plus"
      @click="selectModule"
    />
  </div>
</template>
