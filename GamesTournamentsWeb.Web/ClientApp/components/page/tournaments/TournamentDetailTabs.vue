<script lang="ts" setup>
import type { TournamentDetail } from '~/models/tournaments/TournamentDetail'

const tournamentStore = useTournamentsStore()

const detail = computed(() => tournamentStore.tournamentDetail as TournamentDetail)
</script>

<template>
  <TabView class="max-w-xs md:max-w-full">
    <TabPanel :header="$t('tournament_detail.overview')">
      <div></div>
    </TabPanel>
    <TabPanel :header="$t('tournament_detail.rules')">
      <div></div>
    </TabPanel>
    <TabPanel :header="$t('tournament_detail.prizes')">
      <div></div>
    </TabPanel>
    <TabPanel :header="$t('tournament_detail.players')">
      <div></div>
    </TabPanel>
    <TabPanel :header="$t('tournament_detail.matches')">
      <div></div>
    </TabPanel>
    <TabPanel :header="$t('tournament_detail.streams')">
      <div></div>
    </TabPanel>
    <!--    TODO: check for admin -->
    <TabPanel :header="$t('tournament_detail.admin')">
      <div></div>
    </TabPanel>
  </TabView>
</template>

<style scoped>

</style>
