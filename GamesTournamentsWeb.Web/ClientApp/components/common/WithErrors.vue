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

const valid = computed(() => errors.length === 0)

</script>

<template>
  <div class="container-gap">
    <div :class="{'border-error': !valid}">
      <slot />
    </div>
    <span
      v-for="(error, index) in errors"
      :key="`error-${error.$property}-${index}`"
      class="text-error"
    >{{ error.$message }}</span>
  </div>
</template>
