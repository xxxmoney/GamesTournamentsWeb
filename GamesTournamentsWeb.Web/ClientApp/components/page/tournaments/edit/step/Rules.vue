<script lang="ts" setup>
import useVuelidate from '@vuelidate/core'
import constants from '~/constants'

const edit = useTournamentEdit()
const step = useTournamentEditStep()

const { event, listen } = useEventBus()
const { required } = useValidators()

const rules = {
  rules: { required }
}

const v$ = useVuelidate(rules, edit)
const { validate } = useValidate(v$.value.$validate)

listen(constants.events.tournamentEditNextStepRequest, async () => {
  if (step.value === constants.tournamentEditSteps.rules && await validate()) {
    event(constants.events.tournamentEditNextStepConfirm)
  }
})

// TODO: find out how to dirty state

</script>

<template>
  <h1 class="heading mb-lg">{{ $t('tournament_edit.steps.rules') }}</h1>

  <div class="container-gap">
    <CommonWithErrors :errors="v$.rules.$errors">
      <CommonWithLabel
        v-tooltip="$t('tournament_edit.write_rules_tooltip')"
        :label="$t('common.rules')"
        class="gap"
      >
        <CommonTextEditor v-model="edit.rules" />
      </Commonwithlabel>
    </CommonWithErrors>
  </div>
</template>
