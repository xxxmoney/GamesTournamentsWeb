<script lang="ts" setup>
import type { TournamentDetail } from '~/models/tournaments/TournamentDetail'

const { id } = defineProps({
  id: {
    type: Number,
    required: true
  }
})

const tournamentsStore = useTournamentsStore()

await tournamentsStore.getTournamentDetailById(id)

const detail = computed(() => tournamentsStore.tournamentDetail as TournamentDetail)
</script>

<template>
  <div class="inline-flex flex-col gap">
    <div class="w-full max-h-80 rounded-lg shadow overflow-hidden">
      <img :src="detail.game.imageUrl" />
    </div>

    <PageTournamentsTournamentInfo
      :gameName="detail.game.name"
      :name="detail.name"
      :platformName="detail.platform.name"
      :regionName="detail.region.name"
      :startDate="detail.startDate"
    />

    <PageTournamentsTournamentDetailTabs />
  </div>
</template>
