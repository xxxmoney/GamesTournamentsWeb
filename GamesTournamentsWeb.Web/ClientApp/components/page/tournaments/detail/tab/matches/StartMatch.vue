<script lang="ts" setup>
const store = useTournamentsStore()

const successToast = useSuccessToast()
const errorToast = useErrorToast()

const { matchId } = defineProps({
  matchId: {
    type: Number,
    required: true
  }
})

const submit = async () => {
  try {
    await store.updateMatch({ matchId, winnerId: null, startMatch: true, endMatch: false })
    successToast()
  } catch (error) {
    errorToast(error)
  }
}
</script>

<template>
  <div class="container-gap">
    <Button :label="$t('tournament_matches.start_match')" @click="submit" />
  </div>
</template>
