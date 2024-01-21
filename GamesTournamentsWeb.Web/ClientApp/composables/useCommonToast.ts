import constants from '~/constants'

const useErrorToast = () => {
  const toast = useToast()
  const { t } = useI18n()

  const showErrorToast = (exception: unknown | null = null, message: string | null = null) => {
    if (exception) {
      console.error(exception)
    }

    toast.add({
      severity: 'error',
      summary: t('common.error'),
      detail: message ? t(message) : t('common.error_description'),
      life: constants.toastErrorLifeTime
    })
  }
  return showErrorToast
}

const useSuccessToast = () => {
  const toast = useToast()
  const { t } = useI18n()

  const showSuccessToast = (message: string | null = null) => {
    toast.add({
      severity: 'success',
      summary: t('common.success'),
      detail: message ? t(message) : t('common.success_description'),
      life: constants.toastSuccessLifeTime
    })
  }
  return showSuccessToast
}

const useInfoToast = () => {
  const toast = useToast()
  const { t } = useI18n()

  const showInfoToast = (message: string) => {
    toast.add({
      severity: 'info',
      summary: t('common.info'),
      detail: t(message),
      life: constants.toastInfoLifeTime
    })
  }
  return showInfoToast
}

export { useErrorToast, useSuccessToast, useInfoToast }
