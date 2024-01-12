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
  <div
    class="form-container relative aspect-card overflow-hidden cursor-pointer hover"
    @click="goToGameDetail"
  >
    <img :src="game.imageUrl" alt="Image" class="object-cover w-full h-full rounded-xl" />

    <Button :label="$t('common.detail')" />
  </div>
</template>
