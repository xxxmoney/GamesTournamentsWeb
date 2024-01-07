const getLocalData = <T>(key: string, defaultValue: T): T => {
  let finalValue = defaultValue

  const stringValue = localStorage.getItem(key)
  try {
    if (stringValue) {
      finalValue = JSON.parse(stringValue)
    }
  } catch (e) {
    console.error(e)
  }
  return finalValue
}
const setLocalData = <T>(key: string, value: T): T => {
  try {
    const stringValue = isObject(value) ? JSON.stringify(value) : value
    localStorage.setItem(key, stringValue)
  } catch (e) {
    console.error(e)
  }

  return value
}

export { getLocalData, setLocalData }
