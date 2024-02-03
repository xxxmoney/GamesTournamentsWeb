<script lang="ts" setup>

const tournamentsStore = useTournamentsStore()
const router = useRouter()

const { id } = defineProps({
  id: {
    type: Number,
    required: true
  }
})

const tournament = computed(() => tournamentsStore.tournamentById(id))

const goToTournamentDetail = () => {
  router.push(`/tournaments/${id}`)
}
</script>

<template>
  <CommonImageCard :imageUrl="tournament.game.imageUrl" @click="goToTournamentDetail">
    <div class="container-gap-lg">
      <PageTournamentsOverviewInfo
        :gameName="tournament.game.name"
        :name="tournament.name"
        :platformName="tournament.platform.name"
        :regionName="tournament.region.name"
        :startDate="tournament.startDate"
      />

      <Button :label="$t('common.detail')" @click="goToTournamentDetail" />
    </div>
  </CommonImageCard>
</template>
