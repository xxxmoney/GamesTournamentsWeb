<script lang="ts" setup>
const { id } = defineProps({
  id: {
    type: Number,
    required: true
  }
})

const tournamentsStore = useTournamentsStore()

const tournamentDetail = computed(() => tournamentsStore.tournamentById(id))
</script>

<template>
  <div class="container-gap">
  </div>
</template>
