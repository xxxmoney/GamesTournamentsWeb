<script lang="ts" setup>
import type { TournamentPlayer } from '~/models/tournaments/TournamentPlayer'
import { tournamentPlayerStatus } from '~/enums/tournaments/tournamentPlayerStatus'

const router = useRouter()
const accountStore = useAccountStore()
const mainStore = useMainStore()
const successToast = useSuccessToast()
const errorToast = useErrorToast()
const { t } = useI18n()
const confirm = useConfirm()

const invitations = computed(() => accountStore.invitations)
const account = computed(() => mainStore.account)

if (account.value) {
  await accountStore.getInvitations()
}

const goToTournament = (tournamentId: number) => {
  return router.push(`/tournaments/detail/${tournamentId}`)
}

const acceptInvitation = async (invitation: TournamentPlayer) => {
  confirm.require({
    message: t('account_detail.invitation_accept_confirm'),
    header: t('common.confirmation'),
    accept: async () => {
      try {
        await accountStore.acceptInvitation(invitation.id, invitation.gameUsername as string)

        successToast()

        await goToTournament(invitation.tournamentId)
      } catch (e) {
        errorToast(e)
      }
    },
    reject: () => {
    }
  })
}
const rejectInvitation = async (invitation: TournamentPlayer) => {
  confirm.require({
    message: t('account_detail.invitation_reject_confirm'),
    header: t('common.confirmation'),
    accept: async () => {
      try {
        await accountStore.rejectInvitation(invitation.id)

        successToast()

        await goToTournament(invitation.tournamentId)
      } catch (e) {
        errorToast(e)
      }
    },
    reject: () => {
    }
  })
}

const isInvitationPending = (invitation: TournamentPlayer) => {
  return invitation.statusId === tournamentPlayerStatus.pending
}

const isInvitationAccepted = (invitation: TournamentPlayer) => {
  return invitation.statusId === tournamentPlayerStatus.accepted
}

const isInvitationRejected = (invitation: TournamentPlayer) => {
  return invitation.statusId === tournamentPlayerStatus.rejected
}
</script>

<template>
  <div v-if="account" class="form-lg-container-lg">
    <div class="container">
      <DataTable :value="invitations" size="small">
        <Column :header="$t('common.nickname')" field="gameUsername">
          <template #body="{ data }">
            <span v-if="!isInvitationPending(data) || (data as TournamentPlayer).gameUsername">{{
              (data as TournamentPlayer).gameUsername
            }}</span>
            <Inplace v-else>
              <template #display>{{ $t('common.set_nickname') }}</template>
              <template #content>
                <InputText v-model="(data as TournamentPlayer).gameUsername" />
              </template>
            </Inplace>
          </template>
        </Column>
        <Column :header="$t('common.status')" field="gameName">
          <template #body="{ data }">
            <PageTournamentsGameUserStatus :statusId="data!.statusId" />
          </template>
        </Column>
        <Column :header="$t('common.actions')">
          <template #body="{ data }">
            <div v-if="isInvitationPending(data)" class="container-row-gap-sm">
              <Button
                v-tooltip="$t('common.accept')"
                :disabled="!(data as TournamentPlayer).gameUsername"
                icon="pi pi-check"
                @click="acceptInvitation(data)"
              />
              <Button
                v-tooltip="$t('common.reject')"
                icon="pi pi-times"
                @click="rejectInvitation(data)"
              />
            </div>
          </template>
        </Column>
        <Column :header="$t('common.link')">
          <template #body="{ data }">
            <Button :label="$t('common.link')" link @click="goToTournament((data as TournamentPlayer).tournamentId)" />
          </template>
        </Column>
      </DataTable>
    </div>
  </div>
</template>
