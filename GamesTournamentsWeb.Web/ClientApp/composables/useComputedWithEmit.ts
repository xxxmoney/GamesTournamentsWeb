export const useComputedWithEmit = <T>(value: T, emit, key, prefix = 'update') => computed<T>({
  get: () => {
    return value
  },
  set: (value) => {
    emit(`${prefix}:${key}`, value)
  }
})
