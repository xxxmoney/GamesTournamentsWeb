<script lang="ts" setup>
import { Register } from '~/models/user/Register'

const router = useRouter()
const store = useMainStore()
const successToast = useSuccessToast()
const errorToast = useErrorToast()

const registerValue = ref(new Register())

const goToLogin = () => {
  return router.push('/login')
}

const register = async () => {
  try {
    await store.register(registerValue.value)

    successToast('register.success')

    await goToLogin()
  } catch (e) {
    errorToast(e)
  }
}
</script>

<template>
  <div class="form-container mx-auto">
    <CommonInputText v-model="registerValue.username" :label="$t('common.username')" />
    <CommonInputText v-model="registerValue.email" :label="$t('common.email')" />
    <CommonPassword v-model="registerValue.password" :label="$t('common.password')" />
    <CommonPassword v-model="registerValue.passwordConfirm" :label="$t('common.confirm_password')" />

    <Button :label="$t('common.register')" @click="register" />
    <Button :label="$t('common.login')" severity="secondary" @click="goToLogin" />
  </div>
</template>
