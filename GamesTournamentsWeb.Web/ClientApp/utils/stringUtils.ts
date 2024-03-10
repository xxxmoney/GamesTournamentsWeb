const toSnakeCase = (str: string): string => {
  return str.replace(/([a-z0-9])([A-Z])/g, '$1_$2').toLowerCase()
}

export { toSnakeCase }
