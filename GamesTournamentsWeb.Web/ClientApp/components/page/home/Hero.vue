<script lang="ts" setup>
const tryModel = ref({
  email: ''
})

const trySubmit = () => {

}
</script>

<template>
  <div class="form-container text-center">
    <span class="uppercase">{{ $t('home.hero.small_title') }}</span>
    <h1 class="heading">{{ $t('home.hero.title') }}</h1>
    <p>{{ $t('home.hero.description') }}</p>

    <CommonInputText
      v-model="tryModel.email"
      :label="$t('common.email')"
      :showLabel="false"
      class="text-left"
    />
    <Button :label="$t('common.try_now')" @click="trySubmit" />
  </div>
</template>
