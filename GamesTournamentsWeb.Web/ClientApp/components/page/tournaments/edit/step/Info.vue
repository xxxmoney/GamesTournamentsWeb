<script lang="ts" setup>
import { KeyValuePair } from '~/models/KeyValuePair'
import constants from '~/constants'

const gamesStore = useGamesStore()
const tournamentsStore = useTournamentsStore()

const edit = useTournamentEdit()

const gameOverviews = computed(() => gamesStore.gameOverviews)
const platforms = computed(() => tournamentsStore.platforms)
const regions = computed(() => tournamentsStore.regions)
const teamSizes = computed(() => tournamentsStore.teamSizes.map(teamSize => new KeyValuePair(teamSize, teamSize)))
</script>

<template>
  <div class="flex flex-col md:flex-row gap">
    <div class="container-gap">
      <CommonInputText v-model="edit.name" :label="$t('common.name')" />

      <CommonWithLabel :label="$t('tournament_edit.choose_game')">
        <Dropdown
          v-model:modelValue="edit.gameId"
          :options="gameOverviews"
          :placeholder="$t('tournament_edit.choose_game')"
          :virtualScrollerOptions="{ itemSize: constants.virtualScrollHeight }"
          class=""
          optionLabel="name"
          optionValue="id"
        />
      </CommonWithLabel>

      <CommonWithLabel :label="$t('tournament_edit.choose_platform')">
        <Dropdown
          v-model:modelValue="edit.platformId"
          :options="platforms"
          :placeholder="$t('tournament_edit.choose_platform')"
          class=""
          optionLabel="name"
          optionValue="id"
        />
      </CommonWithLabel>

      <CommonWithLabel :label="$t('tournament_edit.choose_regions')">
        <MultiSelect
          v-model="edit.regionIds"
          :options="regions"
          :placeholder="$t('tournament_edit.choose_regions')"
          :virtualScrollerOptions="{ itemSize: constants.virtualScrollHeight }"
          class="w-full"
          display="chip"
          optionLabel="name"
          optionValue="id"
        />
      </CommonWithLabel>

      <CommonWithLabel :label="$t('tournament_edit.choose_team_size')">
        <Dropdown
          v-model:modelValue="edit.teamSize"
          :options="teamSizes"
          :placeholder="$t('tournament_edit.choose_team_size')"
          class=""
          optionLabel="value"
          optionValue="key"
        />
      </CommonWithLabel>

      <CommonWithLabel :label="$t('common.start_date')">
        <Calendar
          v-model="edit.startDate"
          :minDate="new Date()"
          hourFormat="24"
          showIcon
          showTime
        />
      </CommonWithLabel>

      <CommonWithLabel :label="$t('common.minimum_players')">
        <InputNumber
          v-model="edit.minimumPlayers"
          :max="edit.maximumPlayers ?? constants.tournamentEditMaximumPlayers"
          :min="1"
          :placeholder="$t('common.minimum_players')"
          showButtons
        />
      </commonwithlabel>

      <CommonWithLabel :label="$t('common.maximum_players')">
        <InputNumber
          v-model="edit.maximumPlayers"
          :max="constants.tournamentEditMaximumPlayers"
          :min="edit.minimumPlayers ?? 1"
          :placeholder="$t('common.maximum_players')"
          showButtons
        />
      </commonwithlabel>
    </div>

    <div class="container-gap">
      <CommonWithLabel
        v-tooltip="$t('tournament_edit.write_info_tooltip')"
        :label="$t('common.description')"
        class="gap"
      >
        <CommonTextEditor v-model="edit.info" />
      </commonwithlabel>
    </div>
  </div>
</template>
