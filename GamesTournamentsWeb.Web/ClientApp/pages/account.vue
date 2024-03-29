<script lang="ts" setup>
definePageMeta({
  middleware: 'auth'
})

const router = useRouter()

const mainStore = useMainStore()
const accountStore = useAccountStore()

const account = computed(() => mainStore.account)
if (account.value) {
  await accountStore.getAccountInfo(account.value.id)
}
</script>

<template>
  <div v-if="account" class="form-container-lg mx-auto">
    <PageAccountUserInfo />
    <PageAccountActions />

    <PageAccountPasswordChangeDialog />
    <PageAccountHistoryDialog />
  </div>
</template>
