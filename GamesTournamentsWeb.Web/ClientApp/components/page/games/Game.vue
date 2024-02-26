<script lang="ts" setup>
const gamesStore = useGamesStore()
const router = useRouter()

const { id } = defineProps({
  id: {
    type: Number,
    required: true
  }
})

const game = computed(() => gamesStore.gameById(id))

const goToGameDetail = () => {
  router.push(`/games/${id}`)
}
</script>

<template>
  <CommonImageCard :imageUrl="game.imageUrl" @click="goToGameDetail">
    <Button :label="$t('common.detail')" @click="goToGameDetail" />
  </CommonImageCard>
</template>
