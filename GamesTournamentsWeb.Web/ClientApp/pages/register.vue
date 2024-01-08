<script lang="ts" setup>
const router = useRouter()

const registerValue = ref({
  username: '',
  email: '',
  password: '',
  confirmPassword: ''
})

const goToLogin = () => {
  router.push('/login')
}

const register = () => {
  router.push('/')
}
</script>

<template>
  <div class="form-container mx-auto">
    <CommonInputText v-model="registerValue.username" :label="$t('common.username')" />
    <CommonInputText v-model="registerValue.email" :label="$t('common.email')" />
    <CommonPassword v-model="registerValue.password" :label="$t('common.password')" />
    <CommonPassword v-model="registerValue.confirmPassword" :label="$t('common.confirm_password')" />

    <Button :label="$t('common.register')" @click="register" />
    <Button :label="$t('common.login')" severity="secondary" @click="goToLogin" />
  </div>
</template>
