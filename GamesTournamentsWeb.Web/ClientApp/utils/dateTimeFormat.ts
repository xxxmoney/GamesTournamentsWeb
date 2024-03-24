import { DateTime } from 'luxon'

const formatDate = (date: DateTime): string => {
  return date.toLocaleString(DateTime.DATETIME_MED)
}
const formatJsDate = (date: Date): string => {
  return DateTime.fromJSDate(new Date(date)).toLocaleString(DateTime.DATETIME_MED)
}

const timeDifferenceJs = (date: Date, otherDate: Date | null = null): string => {
  if (!otherDate) {
    otherDate = DateTime.now().toUTC().toJSDate()
  }

  const difference = DateTime
    .fromJSDate(new Date(date))
    .diff(DateTime.fromJSDate(otherDate))

  return difference.toFormat("h'h' m'm'")
}

export { formatDate, formatJsDate, timeDifferenceJs }
