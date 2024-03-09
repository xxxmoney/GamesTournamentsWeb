<script lang="ts" setup>
const store = useDashboardStore()

const showCreateLayoutDialog = () => {
  store.openUpsertLayoutModal()
}

</script>

<template>
  <div class="inline-flex justify-center items-center mx-auto h-96">
    <div class="text-center">
      <h1 class="subheading font-bold">{{ $t('dashboard.no_view.title') }}</h1>
      <p class="mt">
        <i18nT keypath="dashboard.no_view.subtitle">
          <template #create>
            <span class="hover cursor-pointer underline color-primary lowercase" @click="showCreateLayoutDialog">
              {{ $t('common.create') }}
            </span>
          </template>
        </i18nT>
      </p>
    </div>
  </div>
</template>
