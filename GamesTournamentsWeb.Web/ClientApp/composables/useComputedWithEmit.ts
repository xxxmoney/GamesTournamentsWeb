export const useComputedWithEmit = (value, emit, key) => computed({
  get: () => {
    return value
  },
  set: (value) => {
    emit(`update:${key}`, value)
  }
})
