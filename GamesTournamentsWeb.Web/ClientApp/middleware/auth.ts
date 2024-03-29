export default defineNuxtRouteMiddleware(async (_, to) => {
  const store = useMainStore()
  await store.testAuthentication()

  if (process.server) {
    return
  }

  // TODO implement checking for roles in the future
  if (!store.isLoggedIn && to.path !== '/login') {
    return '/login'
  }
})
