<script lang="ts" setup>
import { tournamentPlayerStatus } from '~/enums/tournaments/tournamentPlayerStatus'

const router = useRouter()
const mainStore = useMainStore()
const accountStore = useAccountStore()
const tournamentsStore = useTournamentsStore()
const detail = useTournamentDetail()
const isTournamentFinished = useIsTournamentDetailFinished()
const isTournamentStarted = useIsTournamentDetailStarted()

const successToast = useSuccessToast()
const errorToast = useErrorToast()

const account = computed(() => mainStore.account)
const players = computed(() => detail.value.players)
const gameUsername = ref<string | null>(null)
const triedToClickJoinTournament = ref(false)
const canJoinTournament = computed(() => {
  return account.value && !isTournamentStarted.value && detail.value.anyoneCanJoin && !players.value.some(p => p.account.id === account.value?.id)
})

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

const joinTournament = async () => {
  try {
    await tournamentsStore.joinTournament(detail.value.id, gameUsername.value as string)

    successToast()
  } catch (e) {
    errorToast(e)
  }
}

</script>

<template>
  <div v-if="canJoinTournament" class="container-row-gap items-end mb-lg">
    <CommonInputText
      v-model="gameUsername"
      :class="{'animate-bounce': triedToClickJoinTournament && !gameUsername}"
      :label="$t('common.game_username')"
      :showLabel="false"
    />

    <div @click="triedToClickJoinTournament = true">
      <Button :disabled="!gameUsername" :label="$t('tournament_players.join_tournament')" @click="joinTournament" />
    </div>
  </div>

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
          icon="pi pi-wrench"
          @click="goToInvitations"
        />
      </template>
    </Column>
  </DataTable>
</template>
