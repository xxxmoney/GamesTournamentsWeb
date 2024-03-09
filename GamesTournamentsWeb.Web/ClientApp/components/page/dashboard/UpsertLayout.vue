<script lang="ts" setup>
const store = useDashboardStore()
const successToast = useSuccessToast()
const errorToast = useErrorToast()

const layoutUpsert = computed(() => store.layoutUpsert)
const isSelectedLayout = computed(() => !!store.selectedLayoutId)

const emit = defineEmits(['upserted'])

const upsert = async () => {
  try {
    const layoutUpserted = await store.upsertLayout(layoutUpsert.value!)
    successToast()
    emit('upserted', layoutUpserted)
  } catch (error) {
    errorToast(error)
  }
}

onMounted(() => {
  if (!store.layoutUpsert) {
    store.setDefaultLayoutUpsert()
  }
})

</script>

<template>
  <div v-if="layoutUpsert" class="form-container">
    <div class="container-gap">
      <CommonInputText v-model="layoutUpsert.name" :label="$t('common.name')" />
    </div>

    <Button :label="isSelectedLayout ? $t('common.save') : $t('common.create')" @click="upsert" />
  </div>
</template>
