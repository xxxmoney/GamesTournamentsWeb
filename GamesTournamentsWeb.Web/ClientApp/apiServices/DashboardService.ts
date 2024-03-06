import { LayoutItem } from '~/models/dashboard/LayoutItem'

export const DashboardService = {
  getLayout (): Promise<LayoutItem[]> {
    const items: LayoutItem[] = [
      {
        id: 1,
        x: 0,
        y: 0,
        w: 1,
        h: 1,
        componentName: 'TournamentList'
      },
      {
        id: 2,
        x: 1,
        y: 0,
        w: 1,
        h: 1,
        componentName: 'TournamentList'
      },
      {
        id: 3,
        x: 0,
        y: 1,
        w: 2,
        h: 1,
        componentName: 'TournamentList'
      }
    ]

    return Promise.resolve(items)
  }
}
