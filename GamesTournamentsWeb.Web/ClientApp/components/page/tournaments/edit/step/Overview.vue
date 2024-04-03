<script lang="ts" setup>
import constants from '~/constants'

const info = ref<HTMLElement | null>(null)
const rules = ref<HTMLElement | null>(null)
const prizes = ref<HTMLElement | null>(null)
const players = ref<HTMLElement | null>(null)
const streams = ref<HTMLElement | null>(null)
const admins = ref<HTMLElement | null>(null)

// Validate component - each should have exposed validate method
const validateComponents = (component: { validate: (withToast: boolean) => Promise<boolean> }): Promise<boolean> => {
  if (component) {
    return component.validate(false)
  }

  return Promise.resolve(true)
}

const { validate } = useValidate(async () => {
  // Call validate on each component

  const validations = await Promise.all([
    validateComponents(info.value as any),
    validateComponents(rules.value as any),
    validateComponents(prizes.value as any),
    validateComponents(players.value as any),
    validateComponents(streams.value as any),
    validateComponents(admins.value as any)
  ])

  return validations.every((validation) => validation)
})

defineExpose({
  info,
  rules,
  prizes,
  players,
  streams,
  admins
})

useTournamentEditNextStepRequestWithValidate(constants.tournamentEditSteps.overview, validate)
</script>

<template>
  <div class="grid grid-cols-1 gap-x-lg gap-y-xl lg:grid-cols-2">
    <div>
      <PageTournamentsEditStepInfo ref="info" class="text-area border border-black" />
    </div>
    <div>
      <PageTournamentsEditStepRules ref="rules" class="text-area" />
    </div>
    <div>
      <PageTournamentsEditStepPrizes ref="prizes" class="text-area" />
    </div>
    <div>
      <PageTournamentsEditStepPlayers ref="players" class="text-area" />
    </div>
    <div>
      <PageTournamentsEditStepStreams ref="streams" class="text-area" />
    </div>
    <div>
      <PageTournamentsEditStepAdmins ref="admins" class="text-area" />
    </div>
  </div>
</template>
