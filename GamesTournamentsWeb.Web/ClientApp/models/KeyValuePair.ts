import { ConvertableToJson } from '~/models/ConvertableToJson'

class KeyValuePair<T, R> extends ConvertableToJson {
  public key: T
  public value: R

  constructor (key: T, value: R) {
    super()

    this.key = key
    this.value = value
  }
}

export { KeyValuePair }
