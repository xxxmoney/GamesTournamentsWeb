<script lang="ts" setup>
const store = useTournamentsStore()
const detail = useTournamentDetail()

const sortedPrizes = computed(() => {
  return detail.value.prizes.sort((a, b) => {
    return a.place - b.place
  })
})

const topThreePrizes = computed(() => {
  const prizes = sortedPrizes.value.slice(0, 3)

  return prizes.map((prize, index) => {
    return {
      ...prize,
      colorClass: index === 0 ? 'text-yellow-400' : index === 1 ? 'text-gray-400' : 'text-amber-700',
      tooltip: index === 0 ? 'tournament_prizes.first_place' : index === 1 ? 'tournament_prizes.second_place' : 'tournament_prizes.third_place'
    }
  })
})
const otherPrizes = computed(() => {
  return sortedPrizes.value.slice(3)
})

const currencyById = (id: number) => {
  return store.currencyById(id)
}
</script>

<template>
  <div class="container-gap">
    <div v-if="topThreePrizes.length" class="container-row-gap mx-auto">
      <PageTournamentsTopPrize
        v-for="(prize, index) in topThreePrizes"
        :key="`top-prize-${index}`"
        v-tooltip="$t(prize.tooltip)"
        :amount="prize.amount"
        :colorClass="prize.colorClass"
        :currencySymbol="currencyById(prize.currencyId)?.symbol"
      />
    </div>

    <Panel
      v-if="otherPrizes.length"
      :header="$t('tournament_prizes.other_prizes')"
      collapsed
      toggleable
    >
      <DataTable :value="otherPrizes" size="small">
        <Column :header="$t('tournament_prizes.place')" field="place"></Column>
        <Column :header="$t('tournament_prizes.amount')" field="amount"></Column>
      </DataTable>
    </Panel>
  </div>
</template>
