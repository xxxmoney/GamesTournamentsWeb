<script lang="ts" setup>
import constants from '~/constants'

const store = useAccountStore()

const isActive = computed({
  get: () => store.invitationsModalActive,
  set: (value) => {
    if (!value) {
      store.closeInvitationsModal()
    }
  }
})

</script>

<template>
  <Dialog
    v-model:visible="isActive"
    :baseZIndex="constants.dialogBaseIndexZ"
    :draggable="false"
    :header="$t('common.invitations')"
    :resizable="false"
    class="max-w-lg!"
    modal
  >
    <div class="flex">
      <PageAccountInvitations class="mx-auto" />
    </div>
  </Dialog>
</template>
