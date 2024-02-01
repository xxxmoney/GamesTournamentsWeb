<script lang="ts" setup>
//const mainStore = useMainStore()
const accountStore = useAccountStore()

const router = useRouter()
const { t } = useI18n()
const successToast = useSuccessToast()
const errorToast = useErrorToast()

//const accountId = computed(() => mainStore.account!.id)

const confirm = useConfirm()

const goToTournaments = () => {
  // TODO: filter to my tournaments and go to tournaments page
}
const goToDashboard = () => {
  // TODO: go to dashboard page
}
const showHistory = () => {
  accountStore.openHistoryModal()
}
const showChangePassword = () => {
  accountStore.openPasswordChangeModal()
}
const onDeleteAccount = () => {
  confirm.require({
    message: t('delete_account.prompt'),
    header: 'Confirmation',
    accept: () => {
      try {
        // TODO: add delete account method

        successToast('delete_account.success')

        router.push('/logout')
      } catch (e) {
        errorToast(e)
      }
    }
  })
}

</script>

<template>
  <div class="container-gap-lg">
    <div class="container-gap">
      <CommonActionLink :label="$t('common.my_tournaments')" @click="goToTournaments" />
      <CommonActionLink :label="$t('common.my_dashboard')" @click="goToDashboard" />
    </div>

    <div class="container-row-gap-sm">
      <Button v-tooltip="$t('common.change_password')" icon="pi pi-wrench" @click="showChangePassword" />
      <Button
        v-tooltip="$t('common.history')"
        icon="pi pi-history"
        severity="secondary"
        @click="showHistory"
      />
      <Button
        v-tooltip="$t('common.delete_account')"
        icon="pi pi-trash"
        severity="danger"
        @click="onDeleteAccount"
      />
    </div>
  </div>
</template>
