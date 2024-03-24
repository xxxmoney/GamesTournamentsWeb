const isObject = (value: any) =>
  value !== null && typeof value === 'object'

const copyObject = (obj: any) => {
  return obj ? JSON.parse(JSON.stringify(obj)) : null
}

function getKeyByValue<T> (object: any, value: T): string | null {
  const keys = Object.keys(object).filter(key => object[key] === value)
  return keys.length > 0 ? keys[0] : null
}

export { isObject, copyObject, getKeyByValue }
