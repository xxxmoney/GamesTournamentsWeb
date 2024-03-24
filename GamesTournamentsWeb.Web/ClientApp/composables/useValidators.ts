import * as validators from '@vuelidate/validators'
import type { ComputedRef } from 'vue'

export const useValidators = () => {
  const { t } = useI18n()
  const { createI18nMessage } = validators

  const withI18nMessage = createI18nMessage({ t })

  const required = withI18nMessage(validators.required)

  const useRequiredIf = (dependantValue: ComputedRef<any>) => withI18nMessage(validators.requiredIf(dependantValue))

  const useRequiredUnless = (dependantValue: ComputedRef<any>) => withI18nMessage(validators.requiredUnless(dependantValue))

  const minLength = withI18nMessage(validators.minLength, { withArguments: true })

  const maxLength = withI18nMessage(validators.maxLength(10))

  const url = withI18nMessage(validators.url)

  const email = withI18nMessage(validators.email)

  const useSameAs = (dependantValue: ComputedRef<any>) => withI18nMessage(validators.sameAs(dependantValue))

  const helpers = validators.helpers

  return {
    required, useRequiredIf, useRequiredUnless, minLength, maxLength, helpers, url, email, useSameAs
  }
}
