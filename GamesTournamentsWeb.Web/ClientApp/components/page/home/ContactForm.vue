<script lang="ts" setup>
const contactFormValue = ref({
  name: '',
  surname: '',
  email: '',
  message: ''
})

const submit = () => {

}
</script>

<template>
  <div class="form-container">
    <h2 class="subheading">{{ $t('home.contact_form.title') }}</h2>

    <span class="cursive">{{ $t('home.contact_form.subtitle') }}</span>

    <CommonInputText v-model="contactFormValue.name" :label="$t('common.name') + ' *'" />
    <CommonInputText v-model="contactFormValue.surname" :label="$t('common.surname')" />
    <CommonInputText v-model="contactFormValue.email" :label="$t('common.email') + ' *'" />
    <CommonInputArea v-model="contactFormValue.message" :label="$t('common.message') + ' *'" />

    <span class="italic">{{ $t('home.contact_form.info') }}</span>

    <Button :label="$t('common.submit')" @click="submit" />
  </div>
</template>
