import type { Layout } from '~/models/dashboard/Layout'
import type { LayoutItem } from '~/models/dashboard/LayoutItem'
import type { LayoutUpsert } from '~/models/dashboard/LayoutUpsert'
import type { LayoutOverview } from '~/models/dashboard/LayoutOverview'

export const DashboardService = {
  async getLayouts (): Promise<Layout[]> {
    const api = useApi()
    const result = await api.get<Layout[]>('dashboard/layouts')
    return result.data
  },
  async upsertLayout (layoutUpsert: LayoutUpsert): Promise<LayoutOverview> {
    const api = useApi()
    const result = await api.post<LayoutOverview>('dashboard/layouts/upsert', layoutUpsert)
    return result.data
  },
  async removeLayout (layoutId: number): Promise<void> {
    const api = useApi()
    await api.delete(`dashboard/layouts/${layoutId}/remove`)
  },
  async upsertLayoutItems (layoutId: number, items: LayoutItem[]): Promise<LayoutItem[]> {
    const api = useApi()
    const result = await api.post<LayoutItem[]>('dashboard/layouts/items/upsert', { layoutId, items })
    return result.data
  }

}
