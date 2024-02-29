import type { ObjectSchema, ValidationError } from 'yup'
import type { ValidationResult } from '~/models/ValidationResult'

/**
 * Recursively get all validation errors from a Yup ValidationError
 * @param error
 */
const getAllValidationErrors = (error: ValidationError): ValidationError[] => {
  if (error.inner.length === 0) {
    return [error]
  }

  return error.inner.flatMap((innerError) => getAllValidationErrors(innerError))
}

const mapToValidationResult = (isValid: boolean, errors: ValidationError[]): ValidationResult => ({
  isValid,
  errors: new Map(errors.map((error) => [error.path as string, {
    path: error.path as string,
    value: error.value,
    message: error.message
  }]))
})

export const useYupValidate = (schema: ObjectSchema<any>) => {
  const validation = ref<ValidationResult>(mapToValidationResult(true, []))

  const validateFor = async (value: any): Promise<ValidationResult> => {
    try {
      await schema.validate(value, { abortEarly: false })
      validation.value = mapToValidationResult(true, [])
    } catch (error) {
      console.log(JSON.stringify(error, null, 2))
      const validationError = error as ValidationError
      validation.value = mapToValidationResult(false, getAllValidationErrors(validationError))
    }

    return validation.value
  }

  const getMessage = (path: string): string => {
    const error = validation.value.errors.get(path)
    return error ? error.message : ''
  }

  return { validateFor, getMessage, validation }
}
