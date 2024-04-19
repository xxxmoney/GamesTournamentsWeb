<script lang="ts" setup>
const detail = useTournamentDetail()

const node = computed(() => toMatchTreeNode(detail.value?.matches))
</script>

<template>
  <div v-if="node" class="overflow-auto">
    <OrganizationChart :value="node" class="mt-lg flex-1" collapsible>
      <template #default="slotProps">
        <PageTournamentsDetailTabMatchesMatch :matchId="slotProps.node.key" />
      </template>
    </OrganizationChart>
  </div>
  <div v-else>
    <span>{{ $t('tournament_matches.no_matches') }}</span>
  </div>
</template>
