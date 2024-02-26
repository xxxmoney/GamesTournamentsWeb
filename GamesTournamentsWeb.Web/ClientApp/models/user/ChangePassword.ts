import { ConvertableToJson } from '~/models/ConvertableToJson'

class ChangePassword extends ConvertableToJson {
  public currentPassword: string
  public newPassword: string
  public confirmNewPassword: string

  constructor () {
    super()

    this.currentPassword = ''
    this.newPassword = ''
    this.confirmNewPassword = ''
  }
}

export { ChangePassword }
