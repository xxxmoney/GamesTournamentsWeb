const tryParseInt = (value: string, defaultValue: number | null = null): number | null => {
  const parsedValue = parseInt(value)

  if (isNaN(parsedValue)) {
    return defaultValue
  }

  return parsedValue
}

export { tryParseInt }
