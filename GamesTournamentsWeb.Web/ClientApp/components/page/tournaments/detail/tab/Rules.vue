<script lang="ts" setup>
import sanitizeHtml from 'sanitize-html'

const detail = useTournamentDetail()
</script>

<template>
  <div class="container-gap">
    <h2 class="subheading">{{ $t('tournament_detail.rules') }}</h2>
    <!--  eslint-disable-next-line  -->
    <div v-html="sanitizeHtml(detail.rules)"></div>
  </div>
</template>
