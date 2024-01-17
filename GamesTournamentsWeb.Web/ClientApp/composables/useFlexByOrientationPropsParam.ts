export const useFlexByOrientationPropsParam = () => ({
  type: String,
  default: 'row',
  validator: (value: string) => ['row', 'col'].includes(value)
})
