import type { Emitter, Handler } from 'mitt'

export const useEventBus = () => {
  const { $emitter } = useNuxtApp()

  const emitter = $emitter as Emitter<Record<string, unknown>>

  const event = (type: string, payload?: unknown) => {
    emitter.emit(type, payload)
  }

  const listen = (type: string, handler: Handler) => {
    emitter.on(type, (payload) => {
      handler(payload)
    })
  }

  return {
    event,
    listen,
    disconnect: emitter.off
  }
}
