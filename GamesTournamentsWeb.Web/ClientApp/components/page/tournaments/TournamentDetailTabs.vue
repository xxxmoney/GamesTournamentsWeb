<script lang="ts" setup>
</script>

<template>
  <TabView class="max-w-xs md:max-w-full">
    <TabPanel :header="$t('tournament_detail.overview')">
      <PageTournamentsTournamentDetailOverview />
    </TabPanel>
    <TabPanel :header="$t('tournament_detail.rules')">
      <PageTournamentsTournamentDetailRules />
    </TabPanel>
    <TabPanel :header="$t('tournament_detail.prizes')">
      <PageTournamentsTournamentDetailPrizes />
    </TabPanel>
    <TabPanel :header="$t('tournament_detail.players')">
      <PageTournamentsTournamentDetailPlayers />
    </TabPanel>
    <TabPanel :header="$t('tournament_detail.matches')">
      <PageTournamentsTournamentDetailMatches />
    </TabPanel>
    <TabPanel :header="$t('tournament_detail.streams')">
      <PageTournamentsTournamentDetailStreams />
    </TabPanel>
    <!--    TODO: check for admin -->
    <TabPanel :header="$t('tournament_detail.admin')">
      <PageTournamentsTournamentDetailAdmin />
    </TabPanel>
  </TabView>
</template>
