<script lang="ts" setup>
import { ChangePassword } from '~/models/user/ChangePassword'

const mainStore = useMainStore()
const changePassword = ref(new ChangePassword())

const router = useRouter()

const errorToast = useErrorToast()
const successToast = useSuccessToast()

const emit = defineEmits(['passwordChanged'])

const login = async () => {
  try {
    if (changePassword.value.newPassword !== changePassword.value.confirmNewPassword) {
      errorToast(null, 'change_password.password_not_matching')
      return
    }

    await mainStore.changePassword(changePassword.value)

    successToast('change_password.success')
    emit('passwordChanged')

    mainStore.logout()
    await router.push('/login')
  } catch (error) {
    errorToast(error, 'change_password.password_incorrect')
  }
}
</script>

<template>
  <div class="form-container-lg">
    <div class="container">
      <CommonInputText v-model="changePassword.currentPassword" :label="$t('common.current_password')" />
      <CommonInputText v-model="changePassword.newPassword" :label="$t('common.new_password')" />
      <CommonInputText v-model="changePassword.confirmNewPassword" :label="$t('common.confirm_new_password')" />
    </div>

    <Button :label="$t('common.change_password')" @click="login" />
  </div>
</template>
