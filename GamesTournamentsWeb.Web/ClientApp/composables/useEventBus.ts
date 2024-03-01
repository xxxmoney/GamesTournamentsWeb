import type { Emitter, Handler } from 'mitt'

export const useEventBus = <T>() => {
  const { $emitter } = useNuxtApp()

  const emitter = $emitter as Emitter<Record<string, unknown>>

  return {
    event: emitter.emit,
    listen: (type: string, handler: Handler) => {
      emitter.off(type)
      emitter.on(type, handler)
    },
    disconnect: emitter.off
  }
}
