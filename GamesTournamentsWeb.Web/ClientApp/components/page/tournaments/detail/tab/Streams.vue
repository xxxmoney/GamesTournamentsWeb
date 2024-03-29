<script lang="ts" setup>
const detail = useTournamentDetail()
</script>

<template>
  <div class="container-gap-lg w-full">
    <template v-if="detail.streams.length">
      <Panel
        v-for="stream in detail.streams"
        :key="`stream-${stream.url}}`"
        :header="stream.name ?? $t('common.stream')"
        collapsed
        toggleable
      >
        <CommonVideoEmbed :src="stream.url" />
      </Panel>
    </template>
    <span v-else>
      {{ $t('tournament_streams.no_streams') }}
    </span>
  </div>
</template>
