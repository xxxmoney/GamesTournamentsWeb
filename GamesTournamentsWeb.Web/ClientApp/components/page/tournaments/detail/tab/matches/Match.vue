<script lang="ts" setup>
import type { Team } from '~/models/tournaments/Team'

const detail = useTournamentDetail()

const { matchId } = defineProps({
  matchId: {
    type: Number,
    required: true
  }
})

const match = computed(() => detail.value.matches.find(m => m.id === matchId)!)

const getClass = (team: Team | null | undefined) => {
  if (match.value.isRunning) {
    return 'text-yellow-500'
  }

  if (!match.value.winner || !team) {
    return 'text-gray-400'
  }

  return match.value.winner!.id === team.id ? 'text-green-500 font-bold' : 'text-red-500 line-through'
}

const firstTeamClass = computed(() => getClass(match.value.firstTeam))
const secondTeamClass = computed(() => getClass(match.value.secondTeam))
const canShowSettings = computed(() => !match.value.winner && (match.value.firstTeam || match.value.secondTeam))
</script>

<template>
  <div
    :class="{'border border-yellow-500': match.isRunning, 'border border-gray-200': !match.isRunning && !match.winner, 'border': match.winner}"
    class="container-row-gap items-center max-w-32 px py md:max-w-52 lg:max-w-80 min-h-8 relative"
  >
    <span v-tooltip="match.firstTeam?.name" :class="firstTeamClass" class="flex-1 truncate">
      {{ match.firstTeam?.name ?? '?' }}
    </span>
    <div
      v-if="match.nextMatchId"
      :class="{'animate-bounce': match.isRunning, 'invisible': match.winner}"
      class="flex-grow-0 flex-shrink-0"
    >
      x
    </div>
    <span
      v-if="match.nextMatchId"
      v-tooltip="match.secondTeam?.name"
      :class="secondTeamClass"
      class="flex-1 truncate"
    >
      {{ match.secondTeam?.name ?? '?' }}
    </span>

    <div v-if="canShowSettings" class="absolute right-0 top-0 translate-x-4 -translate-y-4">
      <CommonButtonPopover
        v-tooltip="$t('common.settings')"
        icon="pi pi-wrench"
        severity="secondary"
      >
        <div class="container-gap">
          <template v-if="match.isRunning && match.firstTeam && match.secondTeam">
            <PageTournamentsDetailTabMatchesSelectWinner :matchId="match.id" />
          </template>
          <template v-else>
            <PageTournamentsDetailTabMatchesStartMatch :matchId="match.id" />
          </template>
        </div>
      </CommonButtonPopover>
    </div>
  </div>
</template>
