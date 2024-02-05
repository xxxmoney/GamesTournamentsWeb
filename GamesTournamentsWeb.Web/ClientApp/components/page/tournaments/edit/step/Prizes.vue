<script lang="ts" setup>
import type { Prize } from '~/models/tournaments/Prize'

const edit = useTournamentEdit()

const removePrize = (prize: Prize) => {
  // TODO: remove prize
}

const addPrize = (place: number) => {
  // TODO: add prize
}

</script>

<template>
  <div class="container-gap">
    <!--    TODO: add button add-->

    <CommonWithButtonIcon
      v-for="prize in edit.prizes"
      :key="`prize-${prize.place}-${prize.amount}`"
      :iconClick="() => removePrize(prize)"
      icon="pi pi-trash"
      severity="danger"
    >
      <span>{{ prize.amount }}</span>
    </CommonWithButtonIcon>

    <PageTournamentsEditNextStepButton />
  </div>
</template>
