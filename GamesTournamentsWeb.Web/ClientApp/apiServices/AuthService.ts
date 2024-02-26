import type { Login } from '~/models/user/Login'
import type { LoginResult } from '~/models/user/LoginResult'
import type { Register } from '~/models/user/Register'
import type { RegisterResult } from '~/models/user/RegisterResult'
import type { ChangePassword } from '~/models/user/ChangePassword'

export const AuthService = {
  login (login: Login): Promise<LoginResult> {
    const role = { id: 1, name: 'user' }
    const account = {
      id: 1,
      name: 'John Doe',
      email: login.email,
      role,
      createdAt: new Date(),
      imageUrl: null
    }
    const result = { token: '69', account }

    return Promise.resolve(result)
  },

  register (register: Register): Promise<RegisterResult> {
    const role = { id: 1, name: 'user' }
    const account = {
      id: 1,
      name: 'John Doe',
      email: register.email,
      role,
      createdAt: new Date(),
      imageUrl: null
    }
    const result = { account }

    return Promise.resolve(result)
  },

  changePassword (request: ChangePassword): Promise<void> {
    return Promise.resolve()
  }
}
