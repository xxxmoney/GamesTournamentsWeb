<script lang="ts" setup>
import type { TournamentPlayer } from '~/models/tournaments/TournamentPlayer'

const detail = useTournamentDetail()

const tournamentPlayersMap = computed(() => {
  const players = detail.value!.players
  const map = new Map<number, TournamentPlayer>()
  players.forEach(p => map.set(p.id, p))
  return map
})

const hasAnyStatistics = computed(() => detail.value!.expectedWinnerStatistics.length > 0)

const options = computed(() => ({
  chart: {
    id: 'expected-winner-statistics-chart'
  },
  labels: detail.value!.expectedWinnerStatistics.map(s => tournamentPlayersMap.value.get(s.expectedWinnerId)!.gameUsername)
}))

const series = computed(() => detail.value!.expectedWinnerStatistics.map(s => s.voteCount))
</script>

<template>
  <div class="container-gap">
    <h2 class="font-bold">{{ $t('tournament_players.expected_winner_chart') }}</h2>

    <CommonChart
      v-if="hasAnyStatistics"
      :options="options"
      :series="series"
      type="donut"
    />
    <span v-else>{{ $t('tournament_players.no_expected_winner_statistics') }}</span>
  </div>
</template>
