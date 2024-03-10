<script lang="ts" setup>
import useVuelidate from '@vuelidate/core'
import { ChangePassword } from '~/models/user/ChangePassword'

const { required, useSameAs } = useValidators()

const mainStore = useMainStore()
const changePasswordValue = ref(new ChangePassword())

const newPassword = computed(() => changePasswordValue.value.newPassword)

const router = useRouter()

const errorToast = useErrorToast()
const successToast = useSuccessToast()

const emit = defineEmits(['passwordChanged'])

const changePassword = async () => {
  try {
    if (!await validate()) {
      return
    }

    await mainStore.changePassword(changePasswordValue.value)

    successToast('change_password.success')
    emit('passwordChanged')

    mainStore.logout()
    await router.push('/login')
  } catch (error) {
    errorToast(error, 'change_password.password_incorrect')
  }
}

const sameAsPassword = useSameAs(newPassword)

const rules = {
  currentPassword: { required, $autoDirty: true },
  newPassword: { required, $autoDirty: true },
  confirmNewPassword: { required, sameAsPassword, $autoDirty: true }
}

const v$ = useVuelidate(rules, changePasswordValue)
const { validate } = useValidate(v$.value.$validate)
</script>

<template>
  <div class="form-container-lg">
    <div class="container-gap">
      <CommonWithErrors :errors="v$.currentPassword.$errors">
        <CommonInputText v-model="changePasswordValue.currentPassword" :label="$t('common.current_password')" />
      </CommonWithErrors>

      <CommonWithErrors :errors="v$.newPassword.$errors">
        <CommonPassword v-model="changePasswordValue.newPassword" :label="$t('common.new_password')" />
      </CommonWithErrors>

      <CommonWithErrors :errors="v$.confirmNewPassword.$errors">
        <CommonPassword v-model="changePasswordValue.confirmNewPassword" :label="$t('common.confirm_new_password')" />
      </CommonWithErrors>
    </div>

    <Button :label="$t('common.change_password')" @click="changePassword" />
  </div>
</template>
