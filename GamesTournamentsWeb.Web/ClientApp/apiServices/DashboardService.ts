import type { LayoutItem } from '~/models/dashboard/LayoutItem'

export const DashboardService = {
  getLayout (): Promise<LayoutItem[]> {
    const items: LayoutItem[] = [
      {
        i: 1,
        x: 0,
        y: 0,
        w: 2,
        h: 2,
        componentName: 'TournamentList',
        layoutId: 1
      }
    ]

    return Promise.resolve(items)
  }
}
