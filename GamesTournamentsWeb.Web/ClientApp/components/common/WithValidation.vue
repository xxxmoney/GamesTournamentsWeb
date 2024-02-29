<script lang="ts" setup>
import type { PropType } from 'vue'
import type { ValidationError } from '~/models/ValidationError'

const { t } = useI18n()

const { errorMessage } = defineProps({
  // errors: {
  //   type: Object as PropType<Map<string, ValidationError>>,
  //   required: true
  // },
  errorMessage: {
    type: String,
    required: true
  }
})

</script>

<template>
  <div class="container-gap">
    <slot></slot>
    <small class="text-red-300">{{ errorMessage }}</small>
  </div>
</template>
