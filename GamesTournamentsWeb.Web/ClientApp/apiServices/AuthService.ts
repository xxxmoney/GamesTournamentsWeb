import type { Login } from '~/models/user/Login'
import type { LoginResult } from '~/models/user/LoginResult'
import type { Register } from '~/models/user/Register'
import type { RegisterResult } from '~/models/user/RegisterResult'
import type { ChangePassword } from '~/models/user/ChangePassword'
import { useApi } from '~/composables/useApi'

export const AuthService = {
  async login (login: Login): Promise<LoginResult> {
    const api = useApi()
    const result = await api.post('auth/login', login)
    return result.data
  },

  async register (register: Register): Promise<RegisterResult> {
    const api = useApi()
    const result = await api.post('auth/register', register)
    return result.data
  },

  async testAuthentication (): Promise<boolean> {
    const api = useApi()
    try {
      await api.get('auth/test')
    } catch {
      return false
    }
    return true
  },

  changePassword (request: ChangePassword): Promise<void> {
    return Promise.resolve()
  }
}
