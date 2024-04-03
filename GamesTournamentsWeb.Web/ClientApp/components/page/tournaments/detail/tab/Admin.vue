<script lang="ts" setup>
const store = useTournamentsStore()
const detail = useTournamentDetail()

const { t } = useI18n()
const router = useRouter()
const confirm = useConfirm()
const successToast = useSuccessToast()
const errorToast = useErrorToast()

const editTournament = async () => {
  await router.push(`/tournaments/edit/${detail.value.id}`)
}
const deleteTournament = () => {
  confirm.require({
    message: t('tournament_delete.prompt'),
    header: t('common.confirmation'),
    accept: async () => {
      try {
        await store.deleteTournamentById(detail.value.id)

        await router.push('/tournaments')

        store.tournamentDetail = null

        successToast('tournament_delete.success')
      } catch (e) {
        errorToast(e)
      }
    }
  })
}
</script>

<template>
  <div class="container-row-gap-sm">
    <Button v-tooltip="$t('tournament_admin.edit')" icon="pi pi-wrench" @click="editTournament" />
    <Button
      v-tooltip="$t('tournament_admin.delete')"
      icon="pi pi-trash"
      severity="danger"
      @click="deleteTournament"
    />
  </div>
</template>
