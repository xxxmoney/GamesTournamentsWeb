<script lang="ts" setup>
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
        // TODO: add delete tournament method

        successToast('tournament_delete.success')

        await router.push('/tournaments')
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
