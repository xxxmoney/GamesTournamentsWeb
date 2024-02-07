<script lang="ts" setup>
import type { Prize } from '~/models/tournaments/Prize'

const edit = useTournamentEdit()
const prizes = computed({
  get: () => edit.value.prizes,
  set: (value: Prize[]) => {
    edit.value.prizes = value
  }
})

const removePrize = (prize: Prize) => {
  prizes.value = prizes.value.filter((p) => p !== prize)
}

const addPrize = () => {
  prizes.value.push({
    place: prizes.value.length + 1,
    amount: 0
  })
}

</script>

<template>
  <div class="container-gap">
    <!--    TODO: add currency selector-->

    <CommonWithButtonIcon
      v-for="prize in edit.prizes"
      :key="`prize-${prize.place}-${prize.amount}`"
      icon="pi pi-trash"
      severity="danger"
      @iconClick="() => removePrize(prize)"
    >
      <InputNumber
        v-model="prize.amount"
        :min="0"
        :placeholder="$t('common.maximum_players')"
        showButtons
      />
    </CommonWithButtonIcon>

    <Button icon="pi pi-plus" @click="addPrize" />
  </div>
</template>
