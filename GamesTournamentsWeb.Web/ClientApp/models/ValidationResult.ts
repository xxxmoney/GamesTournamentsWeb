import type { ValidationError } from '~/models/ValidationError'

interface ValidationResult {
    isValid: boolean;
    errors: Map<string, ValidationError>;
}

export type { ValidationResult }
