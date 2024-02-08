export const useComputedWithEmit = (value, emit, key, prefix = 'update') => computed({
  get: () => {
    return value
  },
  set: (value) => {
    emit(`${prefix}:${key}`, value)
  }
})
