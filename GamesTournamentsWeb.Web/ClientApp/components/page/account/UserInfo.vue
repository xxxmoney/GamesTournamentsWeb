<script lang="ts" setup>
import { Account } from '~/models/user/Account'

const accountStore = useAccountStore()
const mainStore = useMainStore()

const info = computed(() => accountStore.info)
const account = computed(() => mainStore.account as Account)
</script>

<template>
  <div class="form-container-lg m-auto">
    <CommonImageProfile :imageUrl="account.imageUrl as string" :label="account.name" class="items-center" />

    <div class="form-container">
      <!--      TODO-->
    </div>
  </div>
</template>
