<script lang="ts" setup>
import { gamePlayerStatus } from '~/enums/tournaments/gamePlayerStatus'

const { status } = defineProps({
  status: {
    type: String,
    required: true
  }
})

const icon = computed(() => {
  switch (status) {
    case gamePlayerStatus.accepted:
      return 'pi-check'
    case gamePlayerStatus.rejected:
      return 'pi-times'
    case gamePlayerStatus.pending:
      return 'pi-question'
    default:
      return ''
  }
})
</script>

<template>
  <CommonIcon v-tooltip="$t(`tournament_player_status.${status}`)" :icon="icon" size="lg" />
</template>
