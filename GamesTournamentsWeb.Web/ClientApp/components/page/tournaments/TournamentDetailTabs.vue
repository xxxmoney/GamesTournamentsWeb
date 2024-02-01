<script lang="ts" setup>
</script>

<template>
  <TabView class="max-w-xs md:max-w-full">
    <TabPanel :header="$t('tournament_detail.overview')">
      <PageTournamentsTournamentDetailOverview class="text-area" />
    </TabPanel>
    <TabPanel :header="$t('tournament_detail.rules')">
      <PageTournamentsTournamentDetailRules class="text-area" />
    </TabPanel>
    <TabPanel :header="$t('tournament_detail.prizes')">
      <PageTournamentsTournamentDetailPrizes class="text-area" />
    </TabPanel>
    <TabPanel :header="$t('tournament_detail.players')">
      <PageTournamentsTournamentDetailPlayers class="text-area" />
    </TabPanel>
    <TabPanel :header="$t('tournament_detail.matches')">
      <PageTournamentsTournamentDetailMatches class="text-area" />
    </TabPanel>
    <TabPanel :header="$t('tournament_detail.streams')">
      <PageTournamentsTournamentDetailStreams class="text-area" />
    </TabPanel>
    <!--    TODO: check for admin -->
    <TabPanel :header="$t('tournament_detail.admin')">
      <PageTournamentsTournamentDetailAdmin class="text-area" />
    </TabPanel>
  </TabView>
</template>
