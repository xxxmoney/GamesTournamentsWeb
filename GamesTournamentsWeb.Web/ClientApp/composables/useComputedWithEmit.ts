export const useComputedWithEmit = <T>(value: T, emit: any, key: string, prefix = 'update') => computed<T>({
  get: () => {
    return value
  },
  set: (value) => {
    emit(`${prefix}:${key}`, value)
  }
})
