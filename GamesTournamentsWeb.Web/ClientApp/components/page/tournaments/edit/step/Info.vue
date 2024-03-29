<script lang="ts" setup>
import useVuelidate from '@vuelidate/core'
import { KeyValuePair } from '~/models/KeyValuePair'
import constants from '~/constants'

const { required } = useValidators()

const gamesStore = useGamesStore()
const tournamentsStore = useTournamentsStore()

const edit = useTournamentEdit()

const gameOverviews = computed(() => gamesStore.gameOverviews)
const platforms = computed(() => tournamentsStore.platforms)
const regions = computed(() => tournamentsStore.regions)
const teamSizes = computed(() => tournamentsStore.teamSizes.map(teamSize => new KeyValuePair(teamSize, teamSize)))

const rules = {
  name: { required, $autoDirty: true },
  gameId: { required, $autoDirty: true },
  platformId: { required, $autoDirty: true },
  regionIds: { required, $autoDirty: true },
  teamSize: { required, $autoDirty: true },
  startDate: { required, $autoDirty: true },
  minimumPlayers: { required, $autoDirty: true },
  maximumPlayers: { required, $autoDirty: true },
  info: { required, $autoDirty: true }
}

const v$ = useVuelidate(rules, edit)
const { validate } = useValidate(v$.value.$validate)

useTournamentEditNextStepRequestWithValidate(constants.tournamentEditSteps.info, validate)

defineExpose({
  validate
})
</script>

<template>
  <h1 class="heading mb-lg">{{ $t('tournament_edit.steps.info') }}</h1>

  <div class="form-container">
    <div class="container-gap">
      <CommonWithErrors :errors="v$.name.$errors">
        <CommonInputText v-model="edit.name" :label="$t('common.name')" />
      </CommonWithErrors>

      <CommonWithErrors :errors="v$.gameId.$errors">
        <CommonWithLabel :label="$t('common.choose_game')">
          <Dropdown
            v-model:modelValue="edit.gameId"
            :options="gameOverviews"
            :placeholder="$t('common.choose_game')"
            :virtualScrollerOptions="{ itemSize: constants.virtualScrollHeight }"
            filter
            optionLabel="name"
            optionValue="id"
          />
        </CommonWithLabel>
      </CommonWithErrors>

      <CommonWithErrors :errors="v$.platformId.$errors">
        <CommonWithLabel :label="$t('common.choose_platform')">
          <Dropdown
            v-model:modelValue="edit.platformId"
            :options="platforms"
            :placeholder="$t('common.choose_platform')"
            class=""
            optionLabel="name"
            optionValue="id"
          />
        </CommonWithLabel>
      </CommonWithErrors>

      <CommonWithErrors :errors="v$.regionIds.$errors">
        <CommonWithLabel :label="$t('common.choose_regions')">
          <MultiSelect
            v-model="edit.regionIds"
            :optionLabel="item => $t(`enums.region.${toSnakeCase(item.name)}`)"
            :options="regions"
            :placeholder="$t('common.choose_regions')"
            :virtualScrollerOptions="{ itemSize: constants.virtualScrollHeight }"
            class="w-full"
            display="chip"
            optionValue="id"
          />
        </CommonWithLabel>
      </CommonWithErrors>

      <CommonWithErrors :errors="v$.teamSize.$errors">
        <CommonWithLabel :label="$t('common.choose_team_size')">
          <Dropdown
            v-model:modelValue="edit.teamSize"
            :options="teamSizes"
            :placeholder="$t('common.choose_team_size')"
            class=""
            filter
            optionLabel="value"
            optionValue="key"
          />
        </CommonWithLabel>
      </CommonWithErrors>

      <CommonWithErrors :errors="v$.startDate.$errors">
        <CommonWithLabel :label="$t('common.start_date')">
          <Calendar
            v-model="edit.startDate"
            :minDate="new Date()"
            hourFormat="24"
            showIcon
            showTime
          />
        </CommonWithLabel>
      </CommonWithErrors>

      <CommonWithErrors :errors="v$.minimumPlayers.$errors">
        <CommonWithLabel :label="$t('common.minimum_players')">
          <InputNumber
            v-model="edit.minimumPlayers"
            :max="edit.maximumPlayers ?? constants.tournamentEditMaximumPlayers"
            :min="1"
            :placeholder="$t('common.minimum_players')"
            showButtons
          />
        </Commonwithlabel>
      </CommonWithErrors>

      <CommonWithErrors :errors="v$.maximumPlayers.$errors">
        <CommonWithLabel :label="$t('common.maximum_players')">
          <InputNumber
            v-model="edit.maximumPlayers"
            :max="constants.tournamentEditMaximumPlayers"
            :min="edit.minimumPlayers ?? 1"
            :placeholder="$t('common.maximum_players')"
            showButtons
          />
        </commonwithlabel>
      </CommonWithErrors>
    </div>

    <div class="container-gap">
      <CommonWithErrors :errors="v$.info.$errors">
        <CommonWithLabel
          v-tooltip="$t('tournament_edit.write_info_tooltip')"
          :label="$t('common.description')"
          class="gap"
        >
          <CommonTextEditor v-model="edit.info" />
        </commonwithlabel>
      </CommonWithErrors>
    </div>
  </div>
</template>
