import type { Layout } from '~/models/dashboard/Layout'
import type { LayoutItem } from '~/models/dashboard/LayoutItem'
import type { LayoutUpsert } from '~/models/dashboard/LayoutUpsert'
import type { LayoutOverview } from '~/models/dashboard/LayoutOverview'

export const DashboardService = {
  getLayouts (): Promise<Layout[]> {
    const layout = {
      id: 1,
      name: 'View',
      items: [
        {
          i: 1,
          x: 0,
          y: 0,
          w: 2,
          h: 2,
          moduleId: 1,
          layoutId: 1
        }
      ]
    }

    return Promise.resolve([layout])
  },
  upsertLayout (layoutUpsert: LayoutUpsert): Promise<LayoutOverview> {
    const layout = {
      id: 1,
      name: 'View'
    }

    return Promise.resolve(layout)
  },
  upsertLayoutItems (items: LayoutItem[]): Promise<LayoutItem[]> {
    return Promise.resolve(items)
  }
}
