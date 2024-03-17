export default defineNuxtRouteMiddleware(async (_, to) => {
  const store = useMainStore()
  await store.testAuthentication()

  // TODO implement checking for roles in the future
  if (!store.isLoggedIn && to.path !== '/login') {
    return '/login'
  }
})
