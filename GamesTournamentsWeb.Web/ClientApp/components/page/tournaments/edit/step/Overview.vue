<script lang="ts" setup>
const edit = useTournamentEdit()
</script>

<template>
  <div class="container-gap-xl">
    <div>
      <PageTournamentsEditStepInfo class="text-area" />
    </div>
    <div>
      <PageTournamentsEditStepRules class="text-area" />
    </div>
    <div>
      <PageTournamentsEditStepPrizes class="text-area" />
    </div>
    <div>
      <PageTournamentsEditStepPlayers class="text-area" />
    </div>
    <div>
      <PageTournamentsEditStepMatches class="text-area" />
    </div>
    <div>
      <PageTournamentsEditStepStreams class="text-area" />
    </div>
    <div>
      <PageTournamentsEditStepAdmins class="text-area" />
    </div>
  </div>
</template>
