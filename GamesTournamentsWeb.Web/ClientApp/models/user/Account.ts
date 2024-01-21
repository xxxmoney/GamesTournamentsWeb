import { ConvertableToJson } from '~/models/ConvertableToJson'
import { Role } from '~/models/user/Role'

class Account extends ConvertableToJson {
  public id: number
  public name: string
  public email: string
  public role: Role
  public createdAt: Date

  constructor (id: number, name: string, email: string, Role: Role, createdAt: Date) {
    super()

    this.id = id
    this.name = name
    this.email = email
    this.role = Role
    this.createdAt = createdAt
  }
}

export { Account }
