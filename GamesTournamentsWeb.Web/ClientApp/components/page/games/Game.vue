<script lang="ts" setup>
const gamesStore = useGamesStore()
const tournamentsStore = useTournamentsStore()
const router = useRouter()

const { id } = defineProps({
  id: {
    type: Number,
    required: true
  }
})

const game = computed(() => gamesStore.gameById(id))

const filterToGame = async () => {
  tournamentsStore.resetFilter()
  tournamentsStore.filter.gameId = id
  await router.push('/tournaments')
}
</script>

<template>
  <CommonImageCard :imageUrl="game.imageUrl" @click="filterToGame">
    <Button :label="$t('common.detail')" @click="filterToGame" />
  </CommonImageCard>
</template>
