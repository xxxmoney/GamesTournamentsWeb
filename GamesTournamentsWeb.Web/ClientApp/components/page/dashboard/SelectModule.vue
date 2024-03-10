<script lang="ts" setup>
const store = useDashboardStore()

const selectedModuleId = ref<number | null>(null)
const modules = computed(() => store.modules)

const emit = defineEmits(['selected'])

const selectModule = () => {
  if (!selectedModuleId.value) {
    throw new Error('Module Id is not selected')
  }

  store.updateOrAddSelectedLayoutItem(selectedModuleId.value)
  emit('selected', selectedModuleId.value)
}
</script>

<template>
  <div class="form-container mx-auto">
    <CommonWithLabel :label="$t('common.choose_module')">
      <Dropdown
        v-model:modelValue="selectedModuleId"
        :optionLabel="value => $t(`dashboard.modules.${toKebabCase(value.name)}`)"
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
