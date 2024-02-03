import type { OrganizationChartNode } from 'primevue/organizationchart'
import type { Match } from '~/models/tournaments/Match'

const toMatchTreeNodes = (topMatch: Match, allMatches: Match[]): OrganizationChartNode[] => {
  const topMatches = allMatches.filter(match => match.nextMatchId === topMatch.id)

  return topMatches.map(match => ({
    key: match.id,
    label: `Match ${match.id}`,
    children: toMatchTreeNodes(match, allMatches)
  }))
}

const toMatchTreeNode = (matches: Match[]): OrganizationChartNode | null => {
  if (matches.length === 0) {
    return null
  }

  const topMatch = matches.find(match => !match.nextMatchId)!

  return {
    key: topMatch.id,
    label: `Top Match ${topMatch.id}`,
    children: toMatchTreeNodes(topMatch, matches)
  }
}

export { toMatchTreeNode, toMatchTreeNodes }
