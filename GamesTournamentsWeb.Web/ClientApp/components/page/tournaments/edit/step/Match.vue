<script lang="ts" setup>
import useVuelidate from '@vuelidate/core'
import constants from '~/constants'

const { required } = useValidators()

const edit = useTournamentEdit()

const match = computed(() => edit.value.match)

const noMatchRunning = computed(() => !match.value)

const options = computed(() => {
  const options = [
    { label: match.value?.firstTeam?.name, value: match.value?.firstTeam },
    { label: match.value?.secondTeam?.name, value: match.value?.secondTeam }
  ]

  return options
})

const validationMatch = computed(() => ({
  winner: match.value ? match.value.winner : true
}))

const rules = {
  winner: { required, $autoDirty: true }
}

const v$ = useVuelidate(rules, validationMatch)
const { validate } = useValidate(v$.value.$validate)

useTournamentEditNextStepRequestWithValidate(constants.tournamentEditSteps.match, validate)

defineExpose({
  validate
})
</script>

<template>
  <h1 class="heading mb-lg">{{ $t('tournament_edit.steps.match') }}</h1>

  <div class="form-container">
    <template v-if="noMatchRunning">
      <span>{{ $t('tournament_edit.no_match') }}</span>
    </template>

    <template v-else>
      <span>{{ $t('common.winner') }}:</span>
      <CommonWithErrors :errors="v$.winner.$errors">
        <SelectButton
          v-model="match!.winner"
          :options="options"
          optionLabel="label"
          optionValue="value"
        />
      </CommonWithErrors>
    </template>
  </div>
</template>
