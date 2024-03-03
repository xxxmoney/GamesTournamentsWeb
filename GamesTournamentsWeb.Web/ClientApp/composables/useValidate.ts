export const useValidate = (doValidate: () => Promise<boolean>) => {
  const errorToast = useErrorToast()

  const validate = async (withToast = true) => {
    const result = await doValidate()

    if (withToast && !result) {
      errorToast(null, 'validations.error')
    }

    return result
  }

  return {
    validate
  }
}
