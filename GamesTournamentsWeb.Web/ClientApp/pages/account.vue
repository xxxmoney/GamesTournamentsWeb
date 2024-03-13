<script lang="ts" setup>
definePageMeta({
  middleware: 'auth'
})

const router = useRouter()

const mainStore = useMainStore()
const accountStore = useAccountStore()

const account = mainStore.account
if (!account) {
  await router.push('/login')
} else {
  await accountStore.getAccountInfo(account.id)
}
</script>

<template>
  <div class="form-container-lg mx-auto">
    <PageAccountUserInfo />
    <PageAccountActions />

    <PageAccountPasswordChangeDialog />
    <PageAccountHistoryDialog />
  </div>
</template>
