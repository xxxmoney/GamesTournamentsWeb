import { ConvertableToJson } from '~/models/ConvertableToJson'

class Register extends ConvertableToJson {
  public username: string
  public email: string
  public password: string
  public passwordConfirm: string

  constructor () {
    super()

    this.username = ''
    this.email = ''
    this.password = ''
    this.passwordConfirm = ''
  }
}

export { Register }
