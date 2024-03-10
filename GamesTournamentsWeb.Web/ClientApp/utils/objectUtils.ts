const isObject = (value: any) =>
  value !== null && typeof value === 'object'

const copyObject = (obj: any) => {
  return obj ? JSON.parse(JSON.stringify(obj)) : null
}

export { isObject, copyObject }
