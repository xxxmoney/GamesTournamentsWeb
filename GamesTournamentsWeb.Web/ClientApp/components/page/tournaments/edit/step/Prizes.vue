<script lang="ts" setup>
import type { Prize } from '~/models/tournaments/Prize'

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
    prizes.values?.forEach((prize) => {
      prize.currencyId = value
    })
  }
})
const currentCurrency = computed(() => tournamentsStore.currencyById(currentCurrencyId.value))

const removePrize = (index: Number) => {
  prizes.value.splice(index, 1)
}

const addPrize = () => {
  prizes.value.push({
    place: prizes.value.length + 1,
    currencyId: currentCurrencyId.value
  })
}

</script>

<template>
  <div class="container-gap">
    <CommonWithLabel :label="$t('common.currency')">
      <Dropdown
        v-model="currentCurrencyId"
        :optionLabel="item => $t(`currencies.${item.code.toLowerCase()}`) + ' - ' + item.symbol"
        :options="currencies"
        class=""
        optionValue="id"
      />
    </CommonWithLabel>

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

    <Button v-tooltip="$t('tournament_edit.add_prize_tooltip')" icon="pi pi-plus" @click="addPrize" />
  </div>
</template>
