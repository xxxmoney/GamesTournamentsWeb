<script lang="ts" setup>
import { object, string } from 'yup'

const edit = useTournamentEdit()

const schema = object({
  rules: string().required()
})

const { validateFor, getMessage } = useYupValidate(schema)

const validate = () => {
  validateFor(edit.value)
}

// IDEA: get keyes from schema and then watch those keys for changes and validate on change

// TODO: add event bridge or smth to catch when next is step button is clicked

</script>

<template>
  <h1 class="heading mb-lg">{{ $t('tournament_edit.steps.rules') }}</h1>

  <div class="container-gap">
    <CommonWithValidation :errorMessage="$t(getMessage('rules'))">
      <CommonWithLabel
        v-tooltip="$t('tournament_edit.write_rules_tooltip')"
        :label="$t('common.rules')"
        class="gap"
      >
        <CommonTextEditor v-model="edit.rules" />
      </Commonwithlabel>
    </CommonWithValidation>

    <Button class="mt-lg" @click="validate">{{ $t('common.save') }}</Button>
  </div>
</template>
