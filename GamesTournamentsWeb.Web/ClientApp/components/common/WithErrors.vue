<script lang="ts" setup>
import type { ErrorObject } from '@vuelidate/core'
import type { PropType } from 'vue'

const { t } = useI18n()

const { errors } = defineProps({
  errors: {
    type: Array as PropType<ErrorObject[]>,
    required: true
  }
})

const invalid = computed(() => Boolean(errors))

</script>

<template>
  <div class="container-gap-sm">
    <slot :invalid="invalid" />
    <span
      v-for="(error, index) in errors"
      :key="`error-${error.$property}-${index}`"
      class="text-error"
    >{{ error.$message }}</span>
  </div>
</template>
