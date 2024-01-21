import { defineStore } from 'pinia'
import { Account } from '~/models/user/Account'
import { Login } from '~/models/user/Login'
import { Role } from '~/models/user/Role'
import type { LoginResult } from '~/models/user/LoginResult'
import type { RegisterResult } from '~/models/user/RegisterResult'
import { Register } from '~/models/user/Register'

export const useMainStore = defineStore({
  id: 'main-store',
  state: () => ({
    isLoggedIn: false,
    loginResult: null as LoginResult | null,
    mobileMenuActive: false
  }),
  actions: {
    initialize (): Promise<void> {
      this.getLoginResult()

      return Promise.resolve()
    },

    openMobileMenu (): void {
      this.mobileMenuActive = true
    },
    closeMobileMenu (): void {
      this.mobileMenuActive = false
    },

    getLoginResult (): LoginResult | null {
      // TODO: use to localStorage

      return null
    },
    setLoginResult (loginResult: LoginResult): void {
      // TODO: use to localStorage

      this.loginResult = loginResult
    },

    login (login: Login): Promise<LoginResult> {
      const role = new Role(1, 'user')
      const account = new Account(1, 'John Doe', login.email, role, new Date())
      this.setLoginResult({ token: '69', account })

      return Promise.resolve(this.loginResult as LoginResult)
    },
    register (register: Register): Promise<RegisterResult> {
      if (register.password !== register.passwordConfirm) {
        return Promise.reject('Passwords do not match')
      }

      const role = new Role(1, 'user')
      const account = new Account(1, 'John Doe', register.email, role, new Date())

      return Promise.resolve({ account })
    },
    logout (): void {
      this.loginResult = null
    }
  },
  getters: {
    isLoggedIn (): boolean {
      return !!this.loginResult
    }
  }
})

if (import.meta.hot) {
  import.meta.hot.accept(acceptHMRUpdate(useMainStore, import.meta.hot))
}
