<script lang="ts" setup>
const edit = useTournamentEdit()
const step = useTournamentEditStep()
const { t } = useI18n()

const steps = ref([
  {
    label: () => t('tournament_edit.steps.info')
  },
  {
    label: () => t('tournament_edit.steps.rules')
  },
  {
    label: () => t('tournament_edit.steps.prizes')
  },
  {
    label: () => t('tournament_edit.steps.players')
  },
  {
    label: () => t('tournament_edit.steps.matches')
  },
  {
    label: () => t('tournament_edit.steps.streams')
  },
  {
    label: () => t('tournament_edit.steps.admins')
  },
  {
    label: () => t('tournament_edit.steps.overview')
  },
  {
    label: () => t('tournament_edit.steps.finish')
  }
])
</script>

<template>
  <div class="container-gap">
    <div class="flex overflow-auto">
      <Steps
        v-model:activeStep="step"
        :model="steps"
        :readonly="false"
        class="mx-auto"
      />
    </div>

    <Divider />

    <TabView v-model:activeIndex="step">
      <TabPanel>
        <PageTournamentsEditStepInfo class="text-area" />
      </TabPanel>
    </TabView>
  </div>
</template>

<style scoped>
:deep(.p-tabview-nav-container) {
  @apply hidden
}
</style>
