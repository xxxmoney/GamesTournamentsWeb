<script lang="ts" setup>
import { Login } from '~/models/user/Login'

const router = useRouter()
const store = useMainStore()
const successToast = useSuccessToast()
const errorToast = useErrorToast()

const loginValue = ref(new Login())

const goToRegister = () => {
  return router.push('/register')
}

const login = async () => {
  try {
    await store.login(loginValue.value)

    successToast('login.success')

    await router.push('/')
  } catch (e) {
    errorToast(e)
  }
}
</script>

<template>
  <div class="form-container mx-auto">
    <CommonInputText v-model="loginValue.email" :label="$t('common.email')" />
    <CommonPassword v-model="loginValue.password" :label="$t('common.password')" />

    <Button :label="$t('common.login')" @click="login" />
    <Button :label="$t('common.register')" severity="secondary" @click="goToRegister" />
  </div>
</template>
