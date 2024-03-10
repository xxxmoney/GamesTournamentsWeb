import type { LayoutDetail } from '~/models/dashboard/LayoutDetail'
import type { LayoutItem } from '~/models/dashboard/LayoutItem'
import type { LayoutUpsert } from '~/models/dashboard/LayoutUpsert'
import type { Layout } from '~/models/dashboard/Layout'
import type { Module } from '~/models/dashboard/Module'

export const DashboardService = {
  getModules (): Promise<Module[]> {
    const modules = [
      {
        id: 1,
        name: 'Default'
      }
    ]

    return Promise.resolve(modules)
  },
  getLayouts (userId: number): Promise<LayoutDetail[]> {
    const layout = {
      id: 1,
      name: 'Default',
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
  upsertLayout (layoutUpsert: LayoutUpsert): Promise<Layout> {
    const layout = {
      id: 1,
      name: 'Default',
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

    return Promise.resolve(layout)
  },
  upsertLayoutItems (items: LayoutItem[]): Promise<LayoutItem[]> {
    return Promise.resolve(items)
  }
}
