<script lang="ts" setup>
import constants from '~/constants'

const edit = useTournamentEdit()
const adminIds = computed(() => new Set(edit.value.adminIds))
const selectedAccountId = ref(null)

const accounts = useAccounts()
const accountsFiltered = computed(() => accounts.value.filter((account) => !adminIds.value.has(account.id)))

const getAccountName = (accountId: number) => {
  const account = accounts.value.find((account) => account.id === accountId)
  return account ? account.username : ''
}

const addAdmin = () => {
  if (selectedAccountId.value) {
    edit.value.adminIds.push(selectedAccountId.value)
    selectedAccountId.value = null
  }
}

const removeAdmin = (index: number) => {
  edit.value.adminIds.splice(index, 1)
}
</script>

<template>
  <div class="container-gap">
    <CommonWithLabel :label="$t('tournament_edit.choose_account')">
      <CommonWithButtonIcon :iconDisabled="!selectedAccountId" icon="pi pi-plus" @iconClick="addAdmin">
        <Dropdown
          v-model="selectedAccountId"
          :options="accountsFiltered"
          :placeholder="$t('tournament_edit.choose_account')"
          :virtualScrollerOptions="{ itemSize: constants.virtualScrollHeight }"
          filter
          optionLabel="username"
          optionValue="id"
          showClear
        />
      </CommonWithButtonIcon>
    </CommonWithLabel>

    <CommonWithLabel
      v-for="(adminId, index) in edit.adminIds"
      :key="`admin-${adminId}`"
      :label="$t('common.admin')"
    >
      <CommonWithButtonIcon
        icon="pi pi-trash"
        severity="danger"
        @iconClick="() => removeAdmin(index)"
      >
        <InputText
          :modelValue="getAccountName(adminId)"
          readonly
        />
      </CommonWithButtonIcon>
    </CommonWithLabel>
  </div>
</template>
