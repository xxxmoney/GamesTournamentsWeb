<script lang="ts" setup>
import useVuelidate from '@vuelidate/core'

const router = useRouter()
const store = useMainStore()
const errorToast = useErrorToast()
const { required, email } = useValidators()

const { showTryNow } = defineProps({
  showTryNow: {
    type: Boolean,
    required: true
  }
})

const tryModel = ref({
  email: ''
})

const trySubmit = async () => {
  try {
    if (!await validate()) {
      return
    }

    store.registerValue.email = tryModel.value.email

    await router.push('/register')
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

    <CommonWithErrors v-if="showTryNow" :errors="v$.email.$errors">
      <CommonInputText
        v-model="tryModel.email"
        :label="$t('common.email')"
        :showLabel="false"
        class="text-left"
      />
    </CommonWithErrors>

    <Button v-if="showTryNow" :label="$t('common.try_now')" @click="trySubmit" />
  </div>
</template>
