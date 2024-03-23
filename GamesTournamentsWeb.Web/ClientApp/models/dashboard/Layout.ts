import type { LayoutItem } from '~/models/dashboard/LayoutItem'

interface Layout {
    id: number;
    name: string;
    items: LayoutItem[];
}

export type { Layout }
