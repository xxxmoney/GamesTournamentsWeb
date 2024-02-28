import type { ObjectSchema, ValidationError } from 'yup'
import type { ValidationResult } from '~/models/ValidationResult'

export const useYupValidate = (schema: ObjectSchema<any>) => {
  return async (value: any): Promise<ValidationResult> => {
    try {
      await schema.validate(value, { abortEarly: false })
    } catch (error) {
      return { isValid: false, errors: (error as ValidationError).errors }
    }

    return { isValid: true, errors: [] }
  }
}
