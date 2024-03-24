<script lang="ts" setup>
const detail = useTournamentDetail()
</script>

<template>
  <div class="container-gap">
    <h2 class="subheading">{{ $t('tournament_detail.rules') }}</h2>
    <div v-html="detail.rules"></div>
  </div>
</template>
