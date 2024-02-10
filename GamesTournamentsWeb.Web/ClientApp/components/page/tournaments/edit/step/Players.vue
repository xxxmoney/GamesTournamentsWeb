<script lang="ts" setup>
import constants from '~/constants'

const edit = useTournamentEdit()
const accountsIds = computed(() => new Set(edit.value.players.map((player) => player.accountId)))
const selectedAccountId = ref(null)

const accounts = useAccounts()
const accountsFiltered = computed(() => accounts.value.filter((account) => !accountsIds.value.has(account.id)))

const getAccountName = (accountId: number) => {
  const account = accounts.value.find((account) => account.id === accountId)
  return account ? account.username : ''
}

const addAccount = () => {
  if (selectedAccountId.value) {
    edit.value.players.push({
      accountId: selectedAccountId.value,
      status: 'pending'
    })
    selectedAccountId.value = null
  }
}

const removeAccount = (index: number) => {
  edit.value.players.splice(index, 1)
}
</script>

<template>
  <div class="container-gap">
    <CommonWithLabel :label="$t('tournament_edit.choose_account')">
      <CommonWithButtonIcon :iconDisabled="!selectedAccountId" icon="pi pi-plus" @iconClick="addAccount">
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
      v-for="(player, index) in edit.players"
      :key="`account-${player.accountId}`"
      :label="$t('common.player')"
    >
      <CommonWithButtonIcon
        v-tooltip="getAccountName(player.accountId)"
        icon="pi pi-trash"
        severity="danger"
        @iconClick="() => removeAccount(index)"
      >
        <InputText
          :modelValue="player.gameUsername ?? `? (${getAccountName(player.accountId)})`"
          readonly
        />
      </CommonWithButtonIcon>
    </CommonWithLabel>
  </div>
</template>
