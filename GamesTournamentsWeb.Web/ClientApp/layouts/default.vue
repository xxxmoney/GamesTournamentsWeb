<template>
  <NuxtLoadingIndicator />

  <div class="flex flex-col flex-1">
    <header
      class="flex-grow-0 top-0 sticky z-big background rounded-lg shadow-sm"
    >
      <LayoutDefaultHeader />
    </header>

    <main class="active-area relative flex-1 my-4 lg:my-16 flex col">
      <slot />
    </main>

    <footer class="flex-grow-0">
      <LayoutDefaultFooter />
    </footer>
  </div>

  <LayoutDefaultMobileMenu />

  <Toast />
  <ConfirmDialog />
  <LayoutDefaultLoading />
</template>
