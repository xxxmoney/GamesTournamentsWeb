<script lang="ts" setup>
const store = useTournamentsStore()
const detail = useTournamentDetail()

const successToast = useSuccessToast()
const errorToast = useErrorToast()

const { matchId } = defineProps({
  matchId: {
    type: Number,
    required: true
  }
})

const match = computed(() => detail.value.matches.find(m => m.id === matchId)!)
const winnerId = ref<number | null>(null)

const options = computed(() => {
  const options = [
    { label: match.value.firstTeam!.name, value: match.value.firstTeam!.id },
    { label: match.value?.secondTeam!.name, value: match.value.secondTeam!.id }
  ]

  return options
})

const submit = async () => {
  try {
    await store.updateMatch({ matchId, winnerId: winnerId.value!, startMatch: false, endMatch: true })
    successToast()
  } catch (error) {
    errorToast(error)
  }
}

</script>

<template>
  <div class="container-gap">
    <span>{{ $t('common.winner') }}:</span>
    <SelectButton
      v-model.number="winnerId"
      :options="options"
      optionLabel="label"
      optionValue="value"
    />
    <Button :label="$t('common.submit')" @click="submit" />
  </div>
</template>
