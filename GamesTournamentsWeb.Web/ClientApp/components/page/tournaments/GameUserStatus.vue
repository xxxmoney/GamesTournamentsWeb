<script lang="ts" setup>
import { tournamentPlayerStatus } from '~/enums/tournaments/tournamentPlayerStatus'

const { status } = defineProps({
  status: {
    type: String,
    required: true
  }
})

const icon = computed(() => {
  switch (status) {
    case tournamentPlayerStatus.accepted:
      return 'pi-check'
    case tournamentPlayerStatus.rejected:
      return 'pi-times'
    case tournamentPlayerStatus.pending:
      return 'pi-question'
    default:
      return ''
  }
})
</script>

<template>
  <CommonIcon v-tooltip="$t(`tournament_player_status.${status}`)" :icon="icon" size="lg" />
</template>
