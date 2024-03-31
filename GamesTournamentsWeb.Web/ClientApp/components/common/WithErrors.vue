<script lang="ts" setup>
import type { ErrorObject } from '@vuelidate/core'
import type { PropType } from 'vue'

const { errors } = defineProps({
  errors: {
    type: Array as PropType<ErrorObject[]>,
    required: true
  }
})

</script>

<template>
  <div class="container-gap-sm">
    <div :class="{'border-bottom-error': errors?.length}" class="inline-flex flex-col">
      <slot :invalid="Boolean(errors?.length)" />
    </div>
    <span
      v-for="(error, index) in errors"
      :key="`error-${error.$property}-${index}`"
      class="text-error"
    >{{ error.$message }}</span>
  </div>
</template>
