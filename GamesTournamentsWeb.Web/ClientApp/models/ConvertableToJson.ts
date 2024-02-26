class ConvertableToJson {
  toJson (): Object {
    return { ...this }
  }
}

export { ConvertableToJson }
