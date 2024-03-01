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
    <div>
      <slot :valid="valid" />
    </div>
    <small v-for="error in errors" class="text-red-300">{{ error.$message }}</small>
  </div>
</template>
