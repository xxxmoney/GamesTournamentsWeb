<script lang="ts" setup>
import useVuelidate from '@vuelidate/core'
import constants from '~/constants'

const { required } = useValidators()

const mainStore = useMainStore()
const edit = useTournamentEdit()

const adminIds = computed(() => edit.value.adminIds)
const selectedAccountId = ref(null)

const accountId = computed(() => mainStore.account!.id)
const accounts = useAccounts()
const accountsFiltered = computed(() => accounts.value.filter((account) => !adminIds.value.includes(account.id)))

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

const canRemoveAdmin = (adminId: number) => adminId !== accountId.value

const rules = {
  adminIds: { required, $autoDirty: true }
}

const v$ = useVuelidate(rules, edit)
const { validate } = useValidate(v$.value.$validate)
const invalid = computed(() => v$.value.$invalid)

useTournamentEditNextStepRequestWithValidate(constants.tournamentEditSteps.admins, validate)

defineExpose({
  validate
})
</script>

<template>
  <h1 class="heading mb-lg">{{ $t('tournament_edit.steps.admins') }}</h1>
  <div class="form-container">
    <CommonWithErrors :errors="v$.adminIds.$errors">
      <CommonWithLabel :label="$t('common.choose_account')">
        <CommonWithButtonIcon
          :iconClass="{'animate-pulse': invalid}"
          :iconDisabled="!selectedAccountId"
          icon="pi pi-plus"
          @iconClick="addAdmin"
        >
          <Dropdown
            v-model="selectedAccountId"
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
      v-for="(adminId, index) in edit.adminIds"
      :key="`admin-${adminId}`"
      :label="$t('common.admin')"
    >
      <CommonWithButtonIcon
        :iconDisabled="!canRemoveAdmin(adminId)"
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
