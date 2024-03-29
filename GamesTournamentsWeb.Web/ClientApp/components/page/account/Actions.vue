<script lang="ts" setup>
//const mainStore = useMainStore()
const accountStore = useAccountStore()
const tournamentsStore = useTournamentsStore()

const router = useRouter()
const { t } = useI18n()

const goToTournaments = async () => {
  tournamentsStore.resetFilter()
  tournamentsStore.filter.withMyTournaments = true
  await router.push('/tournaments')
}
const goToDashboard = async () => {
  await router.push('/dashboard')
}
const showHistory = () => {
  accountStore.openHistoryModal()
}
const showChangePassword = () => {
  accountStore.openPasswordChangeModal()
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
    </div>
  </div>
</template>
