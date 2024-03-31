<script lang="ts" setup>
import useVuelidate from '@vuelidate/core'

const { required, email, useSameAs } = useValidators()

const router = useRouter()
const store = useMainStore()
const successToast = useSuccessToast()
const errorToast = useErrorToast()

const registerValue = computed(() => store.registerValue)
const password = computed(() => registerValue.value.password)

const goToLogin = () => {
  return router.push('/login')
}

const register = async () => {
  try {
    if (!await validate()) {
      return
    }

    await store.register(registerValue.value)

    successToast('register.success')

    await goToLogin()
  } catch (e) {
    errorToast(e)
  }
}

onUnmounted(() => {
  store.resetRegisterValue()
})

const sameAsPassword = useSameAs(password)

const rules = {
  username: { required, $autoDirty: true },
  email: { required, email, $autoDirty: true },
  password: { required, $autoDirty: true },
  passwordConfirm: { required, sameAsPassword, $autoDirty: true }
}

const v$ = useVuelidate(rules, registerValue)
const { validate } = useValidate(v$.value.$validate)
</script>

<template>
  <div class="form-container mx-auto">
    <CommonWithErrors :errors="v$.username.$errors">
      <CommonInputText v-model="registerValue.username" :label="$t('common.username')" />
    </CommonWithErrors>

    <CommonWithErrors :errors="v$.email.$errors">
      <CommonInputText v-model="registerValue.email" :label="$t('common.email')" />
    </CommonWithErrors>

    <CommonWithErrors :errors="v$.password.$errors">
      <CommonPassword v-model="registerValue.password" :label="$t('common.password')" />
    </CommonWithErrors>

    <CommonWithErrors :errors="v$.passwordConfirm.$errors">
      <CommonPassword v-model="registerValue.passwordConfirm" :label="$t('common.confirm_password')" />
    </CommonWithErrors>

    <Button :label="$t('common.register')" @click="register" />
    <Button :label="$t('common.login')" severity="secondary" @click="goToLogin" />
  </div>
</template>
