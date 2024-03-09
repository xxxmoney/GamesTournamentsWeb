import type { LayoutItem } from '~/models/dashboard/LayoutItem'

interface LayoutDetail {
    id: number;
    name: string;
    items: LayoutItem[];
}

export type { LayoutDetail }
