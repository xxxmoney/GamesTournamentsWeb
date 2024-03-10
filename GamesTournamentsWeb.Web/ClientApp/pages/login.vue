<script lang="ts" setup>
import useVuelidate from '@vuelidate/core'
import { Login } from '~/models/user/Login'

const { required, email } = useValidators()

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
    if (!await validate()) {
      return
    }

    await store.login(loginValue.value)

    successToast('login.success')

    await router.push('/')
  } catch (e) {
    errorToast(e)
  }
}

const rules = {
  email: { required, email, $autoDirty: true },
  password: { required, $autoDirty: true }
}

const v$ = useVuelidate(rules, loginValue)
const { validate } = useValidate(v$.value.$validate)
</script>

<template>
  <div class="form-container mx-auto">
    <CommonWithErrors :errors="v$.email.$errors">
      <CommonInputText v-model="loginValue.email" :label="$t('common.email')" />
    </CommonWithErrors>

    <CommonWithErrors :errors="v$.password.$errors">
      <CommonPassword v-model="loginValue.password" :label="$t('common.password')" />
    </CommonWithErrors>

    <Button :label="$t('common.login')" @click="login" />
    <Button :label="$t('common.register')" severity="secondary" @click="goToRegister" />
  </div>
</template>
