const toSnakeCase = (str: string): string => {
  return str.replace(/([a-z0-9])([A-Z])/g, '$1_$2').toLowerCase()
}

const toCamelCase = (str: string): string => {
  return str.charAt(0).toLowerCase() + str.slice(1)
}

export { toSnakeCase, toCamelCase }
