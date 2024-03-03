import * as validators from '@vuelidate/validators'

export const useValidators = () => {
  const { t } = useI18n()
  const { createI18nMessage } = validators

  const withI18nMessage = createI18nMessage({ t })

  const required = withI18nMessage(validators.required)

  const minLength = withI18nMessage(validators.minLength, { withArguments: true })

  const maxLength = withI18nMessage(validators.maxLength(10))

  const helpers = validators.helpers

  return {
    required, minLength, maxLength, helpers
  }
}
