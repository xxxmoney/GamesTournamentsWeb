<script lang="ts" setup>
import { tournamentPlayerStatus } from '~/enums/tournaments/tournamentPlayerStatus'

const router = useRouter()
const { t } = useI18n()
const confirm = useConfirm()
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
const tournamentPlayer = computed(() => players.value.find(p => p.accountId === account.value?.id))
const hasNotYetTippedWinner = computed(() => !tournamentPlayer.value?.expectedWinnerId)
const isPartOfTournament = computed(() => !!tournamentPlayer.value)
const canJoinTournament = computed(() => {
  return !isTournamentStarted.value && detail.value.anyoneCanJoin && !isPartOfTournament.value && players.value.length < detail.value.maximumPlayers
})

// Ordered players so that the logged-in user is always first
const orderedPlayers = computed(() => {
  const accountValue = account.value
  return players.value.sort((a, b) => {
    if (a.accountId === accountValue?.id) {
      return -1
    }
    if (b.accountId === accountValue?.id) {
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

    // Hotfix
    location.reload()

    successToast()
  } catch (e) {
    errorToast(e)
  }
}

const tipWinner = (expectedWinnerId: number) => {
  confirm.require({
    message: t('tournament_players.confirm_winner'),
    header: t('common.confirmation'),
    accept: async () => {
      try {
        await tournamentsStore.setTournamentPlayerExpectedWinner(tournamentPlayer.value!.id, expectedWinnerId)
        successToast()
      } catch (e) {
        errorToast(e)
      }
    }
  })
}

</script>

<template>
  <div class="inline-flex flex-col gap">
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

    <div class="inline-flex gap flex-col lg:flex-row">
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
            <div class="container-row-gap-sm">
              <Button
                v-if="isPartOfTournament && hasNotYetTippedWinner && !isTournamentFinished"
                v-tooltip="$t('tournament_players.tip_winner')"
                icon="pi pi-check-square"
                @click="tipWinner(slotProps.data.id)"
              />
              <div v-if="tournamentPlayer?.expectedWinnerId == slotProps.data.id">
                <span
                  v-tooltip="$t('tournament_players.tip_winner')"
                  class="pi pi-check text-xl text-green-500"
                ></span>
              </div>

              <Button
                v-if="slotProps.data.account?.id == account?.id && slotProps.data?.statusId == tournamentPlayerStatus.pending"
                :disabled="isTournamentFinished || isTournamentStarted"
                icon="pi pi-wrench"
                @click="goToInvitations"
              />
            </div>
          </template>
        </Column>
      </DataTable>

      <Divider class="hidden lg:block" layout="vertical" />

      <PageTournamentsDetailTabPlayersChart />
    </div>
  </div>
</template>

<style scoped>
:deep(tr th) {
  padding-top: 0 !important;
}
</style>
