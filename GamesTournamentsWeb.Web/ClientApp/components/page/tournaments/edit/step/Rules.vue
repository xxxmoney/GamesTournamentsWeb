<script lang="ts" setup>
const edit = useTournamentEdit()
</script>

<template>
  <div class="container-gap">
    <CommonWithLabel
      v-tooltip="$t('tournament_edit.write_rules_tooltip')"
      :label="$t('common.rules')"
      class="gap"
    >
      <CommonTextEditor v-model="edit.rules" />
    </commonwithlabel>
  </div>
</template>
