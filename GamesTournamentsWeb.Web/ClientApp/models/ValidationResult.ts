import type { ValidationError } from '~/models/ValidationError'

interface ValidationResult {
    isValid: boolean;
    errors: ValidationError[];
}

export type { ValidationResult }
