import type { Login } from '~/models/user/Login'
import type { LoginResult } from '~/models/user/LoginResult'
import type { Register } from '~/models/user/Register'
import type { RegisterResult } from '~/models/user/RegisterResult'
import type { ChangePassword } from '~/models/user/ChangePassword'
import { useApi } from '~/composables/useApi'

export const AuthService = {
  login (login: Login): Promise<LoginResult> {
    const api = useApi()
    return api.post('auth/login', login)
  },

  register (register: Register): Promise<RegisterResult> {
    const api = useApi()
    return api.post('auth/register', register)
  },

  changePassword (request: ChangePassword): Promise<void> {
    return Promise.resolve()
  }
}
