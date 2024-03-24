<script lang="ts" setup>
import { tournamentPlayerStatus } from '~/enums/tournaments/tournamentPlayerStatus'
import { getKeyByValue } from '~/utils/objectUtils'
import { toSnakeCase } from '~/utils/stringUtils'

const { statusId } = defineProps({
  statusId: {
    type: Number,
    required: true
  }
})

const icon = computed(() => {
  switch (statusId) {
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

const statusName = computed(() => toSnakeCase(getKeyByValue(tournamentPlayerStatus, statusId)))
</script>

<template>
  <CommonIcon v-tooltip="$t(`tournament_player_status.${statusName}`)" :icon="icon" size="lg" />
</template>
