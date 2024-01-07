<script lang="ts" setup>
const router = useRouter()

const loginValue = ref({
  email: '',
  password: ''
})

const goToRegister = () => {
  router.push('/register')
}

const login = () => {
  router.push('/')
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
