<script lang="ts" setup>
import useVuelidate from '@vuelidate/core'

const { required, email } = useValidators()

const successToast = useSuccessToast()
const errorToast = useErrorToast()

const contactFormValue = ref({
  name: '',
  surname: '',
  email: '',
  message: ''
})

const submit = async () => {
  try {
    if (!await validate()) {
      return
    }

    // TODO: add submit

    successToast()
  } catch (e) {
    errorToast(e)
  }
}

const rules = {
  name: { required, $autoDirty: true },
  email: { required, email, $autoDirty: true },
  message: { required, $autoDirty: true }
}

const v$ = useVuelidate(rules, contactFormValue)
const { validate } = useValidate(v$.value.$validate)
</script>

<template>
  <div class="form-container">
    <h2 class="subheading">{{ $t('home.contact_form.title') }}</h2>

    <span class="cursive">{{ $t('home.contact_form.subtitle') }}</span>

    <CommonWithErrors :errors="v$.name.$errors">
      <CommonInputText v-model="contactFormValue.name" :label="$t('common.name') + ' *'" />
    </CommonWithErrors>
    
    <CommonInputText v-model="contactFormValue.surname" :label="$t('common.surname')" />

    <CommonWithErrors :errors="v$.email.$errors">
      <CommonInputText v-model="contactFormValue.email" :label="$t('common.email') + ' *'" />
    </CommonWithErrors>

    <CommonWithErrors :errors="v$.message.$errors">
      <CommonInputArea v-model="contactFormValue.message" :label="$t('common.message') + ' *'" />
    </CommonWithErrors>

    <span class="italic">{{ $t('home.contact_form.info') }}</span>

    <Button :label="$t('common.submit')" @click="submit" />
  </div>
</template>
