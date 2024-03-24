<script lang="ts" setup>
const detail = useTournamentDetail()

const node = computed(() => toMatchTreeNode(detail.value.matches))
</script>

<template>
  <div v-if="node">
    <ScrollPanel>
      <OrganizationChart :value="node" collapsible>
        <template #default="slotProps">
          <div class="px py border">
            <PageTournamentsDetailTabMatchesMatch :matchId="slotProps.node.key" />
          </div>
        </template>
      </OrganizationChart>
    </ScrollPanel>
  </div>
  <div v-else>
    <span class="font-bold">{{ $t('tournament_matches.no_matches') }}</span>
  </div>
</template>
