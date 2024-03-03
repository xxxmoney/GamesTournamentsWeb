<script lang="ts" setup>
import useVuelidate from '@vuelidate/core'
import constants from '~/constants'

const { helpers, required, url } = useValidators()

const edit = useTournamentEdit()
const streams = computed(() => edit.value.streams)

const addStream = () => {
  streams.value.push({
    name: '',
    url: ''
  })
}

const removeStream = (index: number) => {
  streams.value.splice(index, 1)
}

const rules = {
  streams: {
    required,
    $autoDirty: true,
    $each: helpers.forEach({
      name: {
        required
      },
      url: {
        required,
        url
      }
    })
  }
}

const v$ = useVuelidate(rules, edit)
const { validate } = useValidate(v$.value.$validate)
const invalid = computed(() => v$.value.$invalid)

useTournamentEditNextStepRequestWithValidate(constants.tournamentEditSteps.streams, validate)

defineExpose({
  validate
})
</script>

<template>
  <h1 class="heading mb-lg">{{ $t('tournament_edit.steps.streams') }}</h1>

  <div class="container-gap">
    <CommonWithErrors v-if="!streams.length" :errors="v$.streams.$errors">
      <div class="w-full"></div>
    </CommonWithErrors>

    <CommonWithLabel
      v-for="(_, index) in streams"
      :key="`stream-${index}`"
      :label="$t('common.stream')"
    >
      <CommonWithButtonIcon icon="pi pi-trash" severity="danger" @iconClick="() => removeStream(index)">
        <div class="inline-flex flex-col md:flex-row">
          <CommonWithErrors :errors="v$.streams.$each.$response.$errors[index].name">
            <InputText
              v-model="streams[index].name"
              :placeholder="$t('common.stream_name')"
            />
          </CommonWithErrors>

          <CommonWithErrors :errors="v$.streams.$each.$response.$errors[index].url">
            <InputText
              v-model="streams[index].url"
              :placeholder="$t('common.stream_url')"
            />
          </CommonWithErrors>
        </div>
      </CommonWithButtonIcon>
    </CommonWithLabel>

    <Button
      v-tooltip="$t('tournament_edit.add_stream_tooltip')"
      :class="{'animate-pulse': invalid}"
      icon="pi pi-plus"
      @click="addStream"
    />
  </div>
</template>
