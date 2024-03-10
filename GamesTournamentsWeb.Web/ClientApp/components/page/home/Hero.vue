<script lang="ts" setup>
import useVuelidate from '@vuelidate/core'

const { required, email } = useValidators()
const successToast = useSuccessToast()
const errorToast = useErrorToast()

const tryModel = ref({
  email: ''
})

const trySubmit = async () => {
  try {
    if (!await validate()) {
      return
    }

    // TODO: submit try

    successToast()
  } catch (e) {
    errorToast(e)
  }
}

const rules = {
  email: { required, email, $autoDirty: true }
}

const v$ = useVuelidate(rules, tryModel)
const { validate } = useValidate(v$.value.$validate)
</script>

<template>
  <div class="form-container text-center">
    <span class="uppercase">{{ $t('home.hero.small_title') }}</span>
    <h1 class="heading">{{ $t('home.hero.title') }}</h1>
    <p>{{ $t('home.hero.description') }}</p>

    <CommonWithErrors :errors="v$.email.$errors">
      <CommonInputText
        v-model="tryModel.email"
        :label="$t('common.email')"
        :showLabel="false"
        class="text-left"
      />
    </CommonWithErrors>

    <Button :label="$t('common.try_now')" @click="trySubmit" />
  </div>
</template>
