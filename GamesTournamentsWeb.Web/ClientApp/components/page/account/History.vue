<script lang="ts" setup>
import type { HistoryItem } from '~/models/user/HistoryItem'

const accountStore = useAccountStore()
const mainStore = useMainStore()

const router = useRouter()

const history = computed(() => accountStore.history)
const account = computed(() => mainStore.account)

if (account.value) {
  await accountStore.getHistory()
}

const goToTournament = (tournamentId: number) => {
  router.push(`/tournaments/detail/${tournamentId}`)
}

</script>

<template>
  <div v-if="account" class="lg-form-container-lg">
    <div class="container">
      <DataTable :value="history" size="small">
        <Column :header="$t('common.tournament_name')" field="tournamentName"></Column>
        <Column :header="$t('common.game_username')" field="gameUsername"></Column>
        <Column :header="$t('common.game')" field="gameName"></Column>
        <Column :header="$t('common.link')">
          <template #body="{ data }">
            <Button :label="$t('common.link')" link @click="goToTournament((data as HistoryItem).tournamentId)" />
          </template>
        </Column>
      </DataTable>
    </div>
  </div>
</template>
