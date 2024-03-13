export default defineNuxtRouteMiddleware((_, to) => {
  const store = useMainStore()
  // TODO: prolly check each time if token is valid
  // Also, maybe implement checking for roles in the future
  if (!store.isLoggedIn && to.path !== '/login') {
    return '/login'
  }
})
