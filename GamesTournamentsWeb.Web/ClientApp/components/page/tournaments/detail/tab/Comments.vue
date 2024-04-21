<script lang="ts" setup>
import sanitizeHtml from 'sanitize-html'
import type { TournamentComment } from '~/models/tournaments/TournamentComment'

const successToast = useSuccessToast()
const errorToast = useErrorToast()
const mainStore = useMainStore()
const tournamentsStore = useTournamentsStore()

const detail = useTournamentDetail()
const orderedComments = computed(() => detail.value?.comments.sort((a, b) => new Date(b.createDate).getTime() - new Date(a.createDate).getTime()))
const accountId = computed(() => mainStore.account?.id)

const { getAccountName } = useGetAccountName()

const popoverAddComment = ref<HTMLElement | any | null>(null)
const text = ref<string | null>(null)
const addComment = async () => {
  try {
    await tournamentsStore.createTournamentComment({ tournamentId: detail.value!.id, text: text.value as string })
    popoverAddComment.value!.toggle()
    successToast()
  } catch (error) {
    errorToast(error)
  }
}

const clearText = () => {
  text.value = null
}

onMounted(() => {
  clearText()
})
</script>

<template>
  <div class="container-gap">
    <h2 class="subheading">{{ $t('tournament_detail.comments') }}</h2>

    <div>
      <CommonButtonPopover
        v-if="accountId"
        ref="popoverAddComment"
        v-tooltip="$t('tournament_comments.add_comment')"
        icon="pi pi-plus"
        @hide="clearText"
      >
        <div class="container-gap">
          <CommonTextEditor v-model="text" />

          <Button :disabled="!text" :label="$t('common.save')" @click="addComment" />
        </div>
      </CommonButtonPopover>
    </div>

    <DataTable
      :value="orderedComments"
      size="small"
    >
      <Column :header="$t('common.username')">
        <template #body="{ data }">
          <span>{{ getAccountName((data as TournamentComment).accountId) }}</span>
        </template>
      </Column>
      <Column :header="$t('common.create_date')">
        <template #body="{ data }">
          <span>{{ formatJsDate((data as TournamentComment).createDate) }}</span>
        </template>
      </Column>
      <Column :header="$t('common.text')">
        <template #body="{ data }">
          <!--  eslint-disable-next-line  -->
          <div v-html="sanitizeHtml((data as TournamentComment).text)"/>
        </template>
      </Column>
    </DataTable>
  </div>
</template>
