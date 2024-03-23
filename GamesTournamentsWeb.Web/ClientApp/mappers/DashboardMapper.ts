import type { Layout } from '~/models/dashboard/Layout'
import type { LayoutUpsert } from '~/models/dashboard/LayoutUpsert'
import type { LayoutOverview } from '~/models/dashboard/LayoutOverview'

export const DashboardMapper = {
  mapLayoutDetailToLayoutUpsert (layoutDetail: Layout): LayoutUpsert {
    return {
      id: layoutDetail.id,
      name: layoutDetail.name
    }
  },
  mapLayoutUpsertToLayoutDetail (layoutUpsert: LayoutUpsert): Layout {
    return {
      id: layoutUpsert.id!,
      name: layoutUpsert.name,
      items: []
    }
  },
  mapLayoutToLayoutDetail (layout: LayoutOverview): Layout {
    return {
      id: layout.id,
      name: layout.name,
      items: []
    }
  }
}
