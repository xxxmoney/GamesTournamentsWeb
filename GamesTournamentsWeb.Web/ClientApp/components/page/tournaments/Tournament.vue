<script lang="ts" setup>

import { timeDifferenceJs } from '../../../utils/dateTimeFormat'

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
      <h2 class="subheading mt">{{ tournament.name }}</h2>

      <div class="inline-flex flex-row gap">
        <span class="italic">{{ tournament.game.name }}</span>
        <span class="italic">{{ tournament.region.name }}</span>
        <span class="italic">{{ tournament.platform.name }}</span>
      </div>

      <div class="container gap">
        <span>{{ formatJsDate(tournament.startDate) }}</span>
        <span>{{ $t('common.starts_in') }}: {{ timeDifferenceJs(tournament.startDate) }}</span>
      </div>

      <Button :label="$t('common.detail')" @click="goToTournamentDetail" />
    </div>
  </CommonImageCard>
</template>
