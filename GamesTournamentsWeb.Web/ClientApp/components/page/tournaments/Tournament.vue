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
  router.push(`/tournament/${id}`)
}
</script>

<template>
  <CommonImageCard :imageUrl="tournament.game.imageUrl" @click="goToTournamentDetail">
    <div class="container gap-lg">
      <h2 class="subheading">{{ tournament.name }}</h2>

      <div></div>

      <span></span>
      <span></span>

      <Button :label="$t('common.detail')" @click="goToTournamentDetail" />
    </div>
  </CommonImageCard>
</template>
