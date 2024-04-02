<script lang="ts" setup>
import useVuelidate from '@vuelidate/core'
import constants from '~/constants'
import { tournamentPlayerStatus } from '~/enums/tournaments/tournamentPlayerStatus'

const { useRequiredUnless } = useValidators()

const edit = useTournamentEdit()
const isTournamentFinished = useIsTournamentDetailFinished()
const isTournamentStarted = useIsTournamentDetailStarted()

const accountsIds = computed(() => edit.value?.players.map((player) => player.accountId) ?? [])
const selectedAccountId = ref(null)
const anyoneCanJoin = computed(() => edit.value.anyoneCanJoin)

const accounts = useAccounts()
const accountsFiltered = computed(() => accounts.value.filter((account) => !accountsIds.value.includes(account.id)))

const getAccountName = (accountId: number) => {
  const account = accounts.value.find(item => item.id === accountId)
  return account?.username ?? ''
}

const addAccount = () => {
  if (selectedAccountId.value) {
    edit.value.players.push({
      id: 0,
      accountId: selectedAccountId.value,
      statusId: tournamentPlayerStatus.pending,
      gameUsername: null
    })
    selectedAccountId.value = null
  }
}

const removeAccount = (index: number) => {
  edit.value.players.splice(index, 1)
}

const requiredUnless = useRequiredUnless(anyoneCanJoin)
const rules = {
  players: { requiredUnless, $autoDirty: true }
}

const v$ = useVuelidate(rules, edit)
const { validate } = useValidate(v$.value.$validate)
const invalid = computed(() => v$.value.$invalid)

useTournamentEditNextStepRequestWithValidate(constants.tournamentEditSteps.players, validate)

defineExpose({
  validate
})
</script>

<template>
  <h1 class="heading mb-lg">{{ $t('tournament_edit.steps.players') }}</h1>

  <div class="form-container">
    <CommonWithLabel :label="$t('tournament_edit.can_anyone_join')">
      <Checkbox v-model="edit.anyoneCanJoin" :disabled="isTournamentFinished || isTournamentStarted" binary />
    </CommonWithLabel>

    <CommonWithErrors :errors="v$.players.$errors">
      <CommonWithLabel :label="$t('common.choose_account')">
        <CommonWithButtonIcon
          :iconClass="{'animate-pulse': invalid}"
          :iconDisabled="!selectedAccountId || isTournamentFinished || isTournamentStarted"
          icon="pi pi-plus"
          @iconClick="addAccount"
        >
          <Dropdown
            v-model="selectedAccountId"
            :disabled="isTournamentFinished || isTournamentStarted"
            :options="accountsFiltered"
            :placeholder="$t('common.choose_account')"
            :virtualScrollerOptions="{ itemSize: constants.virtualScrollHeight }"
            filter
            optionLabel="username"
            optionValue="id"
            showClear
          />
        </CommonWithButtonIcon>
      </CommonWithLabel>
    </CommonWithErrors>

    <CommonWithLabel
      v-for="(player, index) in edit.players"
      :key="`account-${player.accountId}`"
      :label="$t('common.player')"
    >
      <CommonWithButtonIcon
        v-tooltip="getAccountName(player.accountId)"
        :iconDisabled="isTournamentFinished || isTournamentStarted"
        icon="pi pi-trash"
        severity="danger"
        @iconClick="() => removeAccount(index)"
      >
        <InputText
          :disabled="isTournamentFinished || isTournamentStarted"
          :modelValue="player.gameUsername ?? `? (${getAccountName(player.accountId)})`"
          readonly
        />
      </CommonWithButtonIcon>
    </CommonWithLabel>
  </div>
</template>
