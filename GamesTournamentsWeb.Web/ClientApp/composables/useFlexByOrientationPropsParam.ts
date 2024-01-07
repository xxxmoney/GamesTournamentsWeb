export const useFlexByOrientationPropsParam = () => ({
  orientation: {
    type: String,
    default: 'row',
    validator: (value: string) => ['row', 'col'].includes(value)
  }
})
