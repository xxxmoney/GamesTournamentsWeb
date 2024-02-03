<script lang="ts" setup>
const detail = useTournamentDetail()
</script>

<template>
  <div class="container-gap">
    <h2 class="subheading">{{ $t('tournament_detail.overview') }}</h2>
    <p>{{ detail.info }}</p>
  </div>
</template>
