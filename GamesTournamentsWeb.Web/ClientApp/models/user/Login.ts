import { ConvertableToJson } from '~/models/ConvertableToJson'

class Login extends ConvertableToJson {
  public email: string
  public password: string

  constructor () {
    super()

    this.email = ''
    this.password = ''
  }
}

export { Login }
