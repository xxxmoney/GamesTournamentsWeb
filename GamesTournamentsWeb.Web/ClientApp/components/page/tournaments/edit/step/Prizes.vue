<script lang="ts" setup>
import useVuelidate from '@vuelidate/core'
import type { Prize } from '~/models/tournaments/Prize'
import constants from '~/constants'

const { required } = useValidators()

const tournamentsStore = useTournamentsStore()
const edit = useTournamentEdit()
const prizes = computed({
  get: () => edit.value.prizes,
  set: (value: Prize[]) => {
    edit.value.prizes = value
  }
})
const currencies = computed(() => tournamentsStore.currencies)

const currentCurrencyId = computed({
  get: () => edit.value.currencyId,
  set: (value: number) => {
    if (value === edit.value.currencyId) {
      return
    }

    edit.value.currencyId = value
    prizes.value?.forEach((prize) => {
      prize.currencyId = value
    })
  }
})
const currentCurrency = computed(() => tournamentsStore.currencyById(currentCurrencyId.value))

const removePrize = (index: number) => {
  prizes.value.splice(index, 1)
}

const addPrize = () => {
  prizes.value.push({
    place: prizes.value.length + 1,
    amount: 0,
    currencyId: currentCurrencyId.value
  })
}

const rules = {
  prizes: { required, $autoDirty: true }
}

const v$ = useVuelidate(rules, edit)
const { validate } = useValidate(v$.value.$validate)
const invalid = computed(() => v$.value.$invalid)

useTournamentEditNextStepRequestWithValidate(constants.tournamentEditSteps.prizes, validate)

defineExpose({
  validate
})
</script>

<template>
  <h1 class="heading mb-lg">{{ $t('tournament_edit.steps.prizes') }}</h1>

  <div class="container-gap">
    <CommonWithErrors :errors="v$.prizes.$errors">
      <CommonWithLabel :label="$t('common.currency')">
        <Dropdown
          v-model="currentCurrencyId"
          :optionLabel="item => $t(`currencies.${item.code.toLowerCase()}`) + ' - ' + item.symbol"
          :options="currencies"
          class=""
          optionValue="id"
        />
      </CommonWithLabel>
    </CommonWithErrors>

    <CommonWithLabel
      v-for="(prize, index) in edit.prizes"
      :key="`prize-${prize.place}-${prize.amount}`"
      :label="$t('common.place') + ': ' + prize.place.toString()"
    >
      <CommonWithButtonIcon icon="pi pi-trash" severity="danger" @iconClick="() => removePrize(index)">
        <InputNumber
          v-model="prize.amount"
          :currency="currentCurrency.code"
          :locale="currentCurrency.locale"
          :min="0"
          :placeholder="$t('common.prize')"
          mode="currency"
          showButtons
        />
      </CommonWithButtonIcon>
    </CommonWithLabel>

    <Button
      v-tooltip="$t('tournament_edit.add_prize_tooltip')"
      :class="{'animate-pulse': invalid}"
      icon="pi pi-plus"
      @click="addPrize"
    />
  </div>
</template>
