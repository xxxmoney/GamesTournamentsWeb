<script lang="ts" setup>
const store = useDashboardStore()

const { moduleId } = defineProps({
  moduleId: {
    type: Number,
    required: true
  }
})

const componentName = computed(() => store.moduleById(moduleId)!.name)
</script>

<template>
  <div class="inline-flex flex-col px py">
    <div class="flex-0"></div>

    <component :is="componentName" class="flex-1" />
  </div>
</template>
