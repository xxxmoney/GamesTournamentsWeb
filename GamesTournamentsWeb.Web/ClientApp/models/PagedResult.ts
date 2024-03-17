interface PagedResult<T> {
    currentPage: number
    pageSize: number
    rowCount: number
    pageCount: number
    results: T[]
}

export type { PagedResult }
