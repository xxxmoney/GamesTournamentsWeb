import type { Role } from '~/models/user/Role'

interface Account {
    id: number
    name: string
    email: string
    role: Role
    createdAt: Date
    imageUrl: string | null
}

export type { Account }
