import type { Emitter, Handler } from 'mitt'

const listenHandlerFireDictionary = new Map<string, boolean>()

export const useEventBus = () => {
  const { $emitter } = useNuxtApp()

  const emitter = $emitter as Emitter<Record<string, unknown>>
  
  return {
    event: emitter.emit,
    listen: (type: string, handler: Handler) => emitter.on(type, handler),
    disconnect: emitter.off
  }
}
