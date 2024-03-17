import { defineStore } from 'pinia'
import type { Account } from '~/models/user/Account'
import { Login } from '~/models/user/Login'
import type { LoginResult } from '~/models/user/LoginResult'
import type { RegisterResult } from '~/models/user/RegisterResult'
import { Register } from '~/models/user/Register'
import constants from '~/constants'
import { ChangePassword } from '~/models/user/ChangePassword'
import { AuthService } from '~/apiServices/AuthService'

export const useMainStore = defineStore({
  id: 'main-store',
  state: () => ({
    loading: true,
    loginResult: null as LoginResult | null,
    mobileMenuActive: false,
    locale: constants.defaultLocale
  }),
  actions: {
    initialize (): Promise<void> {
      this.getLoginResult()
      this.getLocale()

      this.loading = false

      return Promise.resolve()
    },

    openMobileMenu (): void {
      this.mobileMenuActive = true
    },
    closeMobileMenu (): void {
      this.mobileMenuActive = false
    },

    getLocale (): string {
      const locale = useCookie<string>(constants.localeKey)

      this.locale = locale.value ?? constants.defaultLocale
      return locale.value
    },
    setLocale (locale: string): void {
      //const localeCookie = useCookie<string>(constants.localeKey)
      this.locale = getLocalData(constants.localeKey, constants.defaultLocale)
    },

    getLoginResult (): LoginResult | null {
      //const login = useCookie<LoginResult | null>(constants.loginKey)
      const result = getLocalData(constants.loginKey, null)

      this.loginResult = result
      return result
    },
    setLoginResult (loginResult: LoginResult | null): void {
      //const login = useCookie<LoginResult | null>(constants.loginKey)
      const result = setLocalData(constants.loginKey, loginResult)

      this.loginResult = result
    },

    async login (login: Login): Promise<LoginResult> {
      try {
        this.loading = true

        const result = await AuthService.login(login)
        this.setLoginResult(result)

        return result
      } finally {
        this.loading = false
      }
    },
    register (register: Register): Promise<RegisterResult> {
      if (register.password !== register.passwordConfirm) {
        return Promise.reject('Passwords do not match')
      }

      try {
        this.loading = true

        return AuthService.register(register)
      } finally {
        this.loading = false
      }
    },
    logout (): void {
      this.setLoginResult(null)
    },
    async changePassword (request: ChangePassword): Promise<void> {
      if (request.newPassword !== request.confirmNewPassword) {
        return Promise.reject()
      }

      try {
        this.loading = true

        const result = await AuthService.changePassword(request)
        return result
      } finally {
        this.loading = false
      }
    }
  },
  getters: {
    isLoggedIn (): boolean {
      return !!this.loginResult
    },
    account (): Account | null {
      return this.loginResult?.account ?? null
    }
  }
})

if (import.meta.hot) {
  import.meta.hot.accept(acceptHMRUpdate(useMainStore, import.meta.hot))
}
