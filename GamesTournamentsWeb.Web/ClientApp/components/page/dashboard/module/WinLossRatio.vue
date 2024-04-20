<script lang="ts" setup>

import type { ModuleWinLossRatioRequest } from '~/models/dashboard/ModuleWinLossRatioRequest'
import Constants from '~/constants'

const { moduleId } = defineProps({
  moduleId: {
    type: Number,
    required: true
  }
})

const { t } = useI18n()
const modulesStore = useModulesStore()
const mainStore = useMainStore()

const request = computed({
  get: () => getLocalData<ModuleWinLossRatioRequest>(`${Constants.modules.winLossRatioKey}-${moduleId}`, { accountId: mainStore.account!.id }),
  set: (value) => setLocalData(Constants.modules.winLossRatioKey, value)
})

const data = computed(() => modulesStore.modules.winLossData.get(moduleId))

const options = computed(() => ({
  chart: {
    id: 'win-loss-ratio-module-chart'
  },
  labels: [t('dashboard.modules.win_loss_ratio.win_count'), t('dashboard.modules.win_loss_ratio.loss_count')],
  colors: ['#63cb67', '#FF5252']
}))

const series = computed(() => [data.value?.winCount ?? 0, data.value?.lossCount ?? 0])

const anyMatches = computed(() => series.value.some(value => value))

onMounted(async () => {
  await modulesStore.getModuleWinLossData(moduleId, request.value)
})

</script>

<template>
  <div>
    <!--    TODO: dropdown select account-->

    <CommonChart
      v-if="anyMatches"
      :options="options"
      :series="series"
      type="donut"
    />
    <span v-else class="font-bold">{{ $t('dashboard.modules.win_loss_ratio.player_no_matches') }}</span>
  </div>
</template>
