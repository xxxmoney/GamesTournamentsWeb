<script lang="ts" setup>
const edit = useTournamentEdit()

const match = computed(() => edit.value.match)

const noMatchRunning = computed(() => !match.value)

const options = computed(() => {
  const options = [
    { label: match.value?.firstTeam?.name, value: match.value?.firstTeam },
    { label: match.value?.firstTeam?.name, value: match.value?.secondTeam }
  ]

  return options
})
</script>

<template>
  <h1 class="heading mb-lg">{{ $t('tournament_edit.steps.match') }}</h1>

  <div class="container-gap">
    <template v-if="noMatchRunning">
      <span>{{ $t('tournament_edit.no_match') }}</span>
    </template>

    <template v-else>
      <span>{{ $t('common.winner') }}:</span>
      <SelectButton
        v-model="match!.winner"
        :options="options"
        optionLabel="label"
        optionValue="value"
      />
    </template>
  </div>
</template>
