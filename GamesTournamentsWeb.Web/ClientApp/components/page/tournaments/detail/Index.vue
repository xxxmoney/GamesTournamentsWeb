<script lang="ts" setup>
const { id } = defineProps({
  id: {
    type: Number,
    required: true
  }
})

const tournamentsStore = useTournamentsStore()

await tournamentsStore.getTournamentById(id)

const detail = computed(() => tournamentsStore.tournamentDetail)
</script>

<template>
  <div v-if="detail" class="container-gap">
    <div class="w-full max-h-80 rounded-lg shadow overflow-hidden">
      <img :src="detail.game.imageUrl" />
    </div>

    <PageTournamentsOverviewInfo
      :gameName="detail.game.name"
      :name="detail.name"
      :platformName="detail.platform.name"
      :regionNames="detail.regions.map(region => region.name)"
      :startDate="detail.startDate"
    />

    <PageTournamentsDetailTabs />
  </div>
</template>
