import type { LayoutDetail } from '~/models/dashboard/LayoutDetail'
import type { LayoutUpsert } from '~/models/dashboard/LayoutUpsert'
import type { Layout } from '~/models/dashboard/Layout'

export const DashboardMapper = {
  mapLayoutDetailToLayoutUpsert (layoutDetail: LayoutDetail): LayoutUpsert {
    return {
      id: layoutDetail.id,
      name: layoutDetail.name
    }
  },
  mapLayoutUpsertToLayoutDetail (layoutUpsert: LayoutUpsert): LayoutDetail {
    return {
      id: layoutUpsert.id!,
      name: layoutUpsert.name,
      items: []
    }
  },
  mapLayoutToLayoutDetail (layout: Layout): LayoutDetail {
    return {
      id: layout.id,
      name: layout.name,
      items: []
    }
  }
}
