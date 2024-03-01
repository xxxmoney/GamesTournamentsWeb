export const useValidate = (doValidate: () => Promise<boolean>) => {
  const errorToast = useErrorToast()

  const validate = async () => {
    const result = await doValidate()

    if (!result) {
      errorToast(null, 'validations.error')
    }

    return result
  }

  return {
    validate
  }
}
