<script lang="ts" setup>
definePageMeta({
  middleware: 'auth'
})

const { id } = defineProps({
  id: {
    type: Number,
    default: null
  }
})

const mainStore = useMainStore()
const tournamentsStore = useTournamentsStore()
const account = computed(() => mainStore.account)
const tournamentExists = computed(() => !!tournamentsStore.tournamentDetail?.id)

onMounted(async () => {
  tournamentsStore.resetTournamentEdit()
  tournamentsStore.resetTournamentDetail()

  if (account.value) {
    if (id) {
      await tournamentsStore.getTournamentById(id)
    }

    tournamentsStore.mapTournamentDetailToEdit(account.value!.id)

    // Go to overview step if tournament exists
    if (tournamentExists.value) {
      tournamentsStore.setTournamentEditStepToLast()
    } else {
      tournamentsStore.resetTournamentEditStep()
    }
  }
})

</script>

<template>
  <PageTournamentsEditSteps v-if="account" class="w-full" />
</template>
