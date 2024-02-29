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
  errors: errors.map((error) => ({
    path: error.path as string,
    value: error.value,
    message: error.message
  }))
})

export const useYupValidate = (schema: ObjectSchema<any>) => {
  return async (value: any): Promise<ValidationResult> => {
    try {
      await schema.validate(value, { abortEarly: false })
    } catch (error) {
      const validationError = error as ValidationError
      return mapToValidationResult(false, getAllValidationErrors(validationError))
    }

    return mapToValidationResult(true, [])
  }
}
