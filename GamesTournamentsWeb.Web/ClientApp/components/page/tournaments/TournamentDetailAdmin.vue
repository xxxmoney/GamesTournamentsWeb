<script lang="ts" setup>
const detail = useTournamentDetail()

const editTournament = () => {
  // TODO: redirect to edit
}
const deleteTournament = () => {
  // TODO: dialog for confirm delete
}
</script>

<template>
  <div class="container-row-gap-sm">
    <Button v-tooltip="$t('tournament_admin.edit')" icon="pi pi-wrench" @click="editTournament" />
    <Button
      v-tooltip="$t('tournament_admin.delete')"
      icon="pi pi-trash"
      severity="danger"
      @click="deleteTournament"
    />
  </div>
</template>
