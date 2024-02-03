<script lang="ts" setup>
const detail = useTournamentDetail()

const { matchId } = defineProps({
  matchId: {
    type: Number,
    required: true
  }
})

const match = computed(() => detail.value.matches.find(m => m.id === matchId)!)
</script>

<template>
  <div class="container-row-gap items-center max-w-32 md:max-w-52 lg:max-w-80 min-h-8">
    <span v-tooltip="match.firstTeam?.name" class="flex-1 truncate">
      {{ match.firstTeam?.name ?? '?' }}
    </span>
    <div v-if="match.nextMatchId" class="flex-grow-0 flex-shrink-0">
      x
    </div>
    <span v-if="match.nextMatchId" v-tooltip="match.secondTeam?.name" class="flex-1 truncate">
      {{ match.secondTeam?.name ?? '?' }}
    </span>
  </div>
</template>
