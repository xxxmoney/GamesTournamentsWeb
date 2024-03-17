<script lang="ts" setup>
import type { Account } from '~/models/user/Account'
import type { AccountInfo } from '~/models/user/AccountInfo'

const accountStore = useAccountStore()
const mainStore = useMainStore()

const info = computed(() => accountStore.info as AccountInfo)
const account = computed(() => mainStore.account as Account)
</script>

<template>
  <div class="form-container-lg mx-auto">
    <CommonImageProfile :imageUrl="account.imageUrl as string" :label="account.username" class="items-center" />

    <div class="container-gap">
      <CommonWithLabel :label="$t('common.matches_played')">
        <span class="font-bold">{{ info.matchesPlayed }}</span>
      </CommonWithLabel>

      <CommonWithLabel :label="$t('common.win_rate')">
        <span class="font-bold">{{ toPercentage(info.winRateRatio) }} %</span>
      </CommonWithLabel>
    </div>
  </div>
</template>
