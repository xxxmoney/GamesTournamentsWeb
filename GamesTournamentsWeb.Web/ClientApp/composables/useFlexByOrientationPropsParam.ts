export const useFlexByOrientationPropsParam = () => ({
  orientation: {
    type: String,
    default: 'row',
    validator: (value) => ['row', 'col'].includes(value)
  }
})
