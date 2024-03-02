<script lang="ts" setup>
import constants from '~/constants'

const store = useTournamentsStore()
const edit = useTournamentEdit()
const step = useTournamentEditStep()
const { t } = useI18n()
const router = useRouter()
const confirm = useConfirm()
const successToast = useSuccessToast()
const errorToast = useErrorToast()

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
    label: () => t('tournament_edit.steps.match')
  },
  {
    label: () => t('tournament_edit.steps.streams')
  },
  {
    label: () => t('tournament_edit.steps.admins')
  },
  {
    label: () => t('tournament_edit.steps.overview')
  }
])

const onFinalize = () => {
  confirm.require({
    message: t('tournament_edit.confirm'),
    header: t('common.confirmation'),
    accept: async () => {
      try {
        // TODO: add upsert call
        const result = { id: 1 }

        successToast('tournament_edit.success')

        await router.push(`/tournaments/detail/${result.id}`)
      } catch (e) {
        errorToast(e)
      }
    },
    reject: () => {
      store.decreaseTournamentEditStep()
    }
  })
}

onMounted(() => {
  store.resetTournamentEditStep()
})
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

    <TabView v-model:activeIndex="step" class="flex-1">
      <TabPanel>
        <PageTournamentsEditStepInfo
          v-if="constants.tournamentEditSteps.info === step"
          class="text-area"
        />
      </TabPanel>
      <TabPanel>
        <PageTournamentsEditStepRules
          v-if="constants.tournamentEditSteps.rules === step"
          class="text-area"
        />
      </TabPanel>
      <TabPanel>
        <PageTournamentsEditStepPrizes
          v-if="constants.tournamentEditSteps.prizes === step"
          class="text-area"
        />
      </TabPanel>
      <TabPanel>
        <PageTournamentsEditStepPlayers
          v-if="constants.tournamentEditSteps.players === step"
          class="text-area"
        />
      </TabPanel>
      <TabPanel>
        <PageTournamentsEditStepMatch
          v-if="constants.tournamentEditSteps.match === step"
          class="text-area"
        />
      </TabPanel>
      <TabPanel>
        <PageTournamentsEditStepStreams
          v-if="constants.tournamentEditSteps.streams === step"
          class="text-area"
        />
      </TabPanel>
      <TabPanel>
        <PageTournamentsEditStepAdmins
          v-if="constants.tournamentEditSteps.admins === step"
          class="text-area"
        />
      </TabPanel>
      <TabPanel>
        <PageTournamentsEditStepOverview
          v-if="constants.tournamentEditSteps.overview === step"
          class="text-area"
        />
      </TabPanel>
    </TabView>

    <Divider />

    <div class="flex flex-row justify-between">
      <PageTournamentsEditPreviousStepButton />
      <PageTournamentsEditNextStepButton @finalize="onFinalize" />
    </div>
  </div>
</template>

<style scoped>
:deep(.p-tabview-nav-container) {
  @apply hidden
}
</style>
