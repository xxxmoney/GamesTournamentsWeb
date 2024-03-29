const getLocalData = <T>(key: string, defaultValue: T): T => {
  let finalValue = defaultValue

  try {
    const stringValue = localStorage.getItem(key)
    if (stringValue) {
      try {
        finalValue = JSON.parse(stringValue) as T
      } catch {
        finalValue = stringValue as T
      }
    }
  } catch (e) {
    console.error(e)
  }
  return finalValue
}
const setLocalData = <T>(key: string, value: T): T => {
  try {
    const stringValue = isObject(value) ? JSON.stringify(value) : value
    localStorage.setItem(key, stringValue as string)
  } catch (e) {
    console.error(e)
  }

  return value
}

export { getLocalData, setLocalData }
