<script lang="ts" setup>
import type { HistoryItem } from '~/models/user/HistoryItem'

const accountStore = useAccountStore()
const mainStore = useMainStore()

const router = useRouter()

const history = computed(() => accountStore.history)
const account = computed(() => mainStore.account)

await accountStore.getHistory(account.value!.id)

const goToTournament = (tournamentId: number) => {
  router.push({ name: 'tournaments', params: { id: tournamentId } })
}

</script>

<template>
  <div class="form-container-lg">
    <div class="container">
      <DataTable :value="history" size="small">
        <Column :header="$t('common.nickname')" field="nickname"></Column>
        <Column :header="$t('common.game')" field="gameName"></Column>
        <Column :header="$t('common.place')" field="place"></Column>
        <Column :header="$t('common.link')">
          <template #body="{ data }">
            <Button :label="$t('common.link')" link @click="goToTournament((data as HistoryItem).tournamentId)" />
          </template>
        </Column>
      </DataTable>
    </div>

    <Paginator :rows="10" :totalRecords="120"></Paginator>
  </div>
</template>
