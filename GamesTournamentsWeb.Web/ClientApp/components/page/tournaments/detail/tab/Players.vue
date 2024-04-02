<script lang="ts" setup>
import { tournamentPlayerStatus } from '~/enums/tournaments/tournamentPlayerStatus'

const router = useRouter()
const mainStore = useMainStore()
const accountStore = useAccountStore()
const detail = useTournamentDetail()
const isTournamentFinished = useIsTournamentDetailFinished()
const isTournamentStarted = useIsTournamentDetailStarted()

const account = computed(() => mainStore.account)
const players = computed(() => detail.value.players)

// Ordered players so that the logged-in user is always first
const orderedPlayers = computed(() => {
  const accountValue = account.value
  return players.value.sort((a, b) => {
    if (a.account.id === accountValue?.id) {
      return -1
    }
    if (b.account.id === accountValue?.id) {
      return 1
    }
    return 0
  })
})

const goToInvitations = async () => {
  accountStore.openInvitationsModal()
  await router.push('/account')
}

</script>

<template>
  <DataTable :value="orderedPlayers" size="small">
    <Column :header="$t('tournament_players.username')" field="account.username"></Column>
    <Column :header="$t('tournament_players.status')">
      <template #body="slotProps">
        <PageTournamentsGameUserStatus :statusId="slotProps.data.statusId" />
      </template>
    </Column>
    <Column :header="$t('common.game_username')" field="gameUsername"></Column>
    <Column header="">
      <template #body="slotProps">
        <Button
          v-if="slotProps.data.account?.id == account?.id && slotProps.data?.statusId == tournamentPlayerStatus.pending"
          :disabled="isTournamentFinished || isTournamentStarted"
          icon="pi pi-check"
          @click="goToInvitations"
        />
      </template>
    </Column>
  </DataTable>
</template>
