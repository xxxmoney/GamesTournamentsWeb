<script lang="ts" setup>
const detail = useTournamentDetail()

const players = computed(() => detail.value.players)
</script>

<template>
  <DataTable :value="players" size="small">
    <Column :header="$t('tournament_players.username')" field="account.username"></Column>
    <Column :header="$t('tournament_players.status')">
      <template #body="slotProps">
        <PageTournamentsGameUserStatus :statusId="slotProps.data.statusId" />
      </template>
    </Column>
    <Column :header="$t('common.game_username')" field="gameUsername"></Column>
  </DataTable>
</template>
