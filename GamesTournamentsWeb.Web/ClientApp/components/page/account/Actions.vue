<script lang="ts" setup>
const mainStore = useMainStore()

const accountId = computed(() => mainStore.account!.id)

const goToTournaments = () => {
  // TODO: filter to my tournaments and go to tournaments page
}
const goToDashboard = () => {
  // TODO: go to dashboard page
}
const goToHistory = () => {
  // TODO: go to history page
}

const onChangePassword = () => {
  // TODO: show change password dialog
}

const onDeleteAccount = () => {
  // TODO: show delete confirmation dialog
}

</script>

<template>
  <div class="container-gap-lg">
    <div class="container-gap">
      <CommonActionLink :label="$t('common.my_tournaments')" @click="goToTournaments" />
      <CommonActionLink :label="$t('common.my_dashboard')" @click="goToDashboard" />
      <CommonActionLink :label="$t('common.history')" @click="goToHistory" />
    </div>

    <div class="container-row-gap">
      <Button v-tooltip="$t('common.change_password')" icon="pi pi-wrench" @click="onChangePassword" />
      <Button
        v-tooltip="$t('common.delete_account')"
        icon="pi pi-trash"
        severity="danger"
        @click="onDeleteAccount"
      />
    </div>
  </div>
</template>
