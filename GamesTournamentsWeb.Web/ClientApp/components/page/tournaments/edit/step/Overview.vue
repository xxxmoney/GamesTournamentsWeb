<script lang="ts" setup>
const edit = useTournamentEdit()
</script>

<template>
  <div class="grid grid-cols-1 gap-x-lg gap-y-xl lg:grid-cols-2">
    <div>
      <PageTournamentsEditStepInfo class="text-area border border-black" />
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
      <PageTournamentsEditStepMatch class="text-area" />
    </div>
    <div>
      <PageTournamentsEditStepStreams class="text-area" />
    </div>
    <div>
      <PageTournamentsEditStepAdmins class="text-area" />
    </div>
  </div>
</template>
