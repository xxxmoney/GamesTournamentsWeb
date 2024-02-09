<script lang="ts" setup>
const edit = useTournamentEdit()
const streams = computed(() => edit.value.streams)

const addStream = () => {
  streams.value.push('')
}

const removeStream = (index: number) => {
  streams.value.splice(index, 1)
}
</script>

<template>
  <div class="container-gap">
    <CommonWithLabel :label="$t('tournament_edit.can_anyone_join')">
      <Checkbox v-model="edit.anyoneCanJoin" binary />
    </CommonWithLabel>

    <CommonWithLabel
      v-for="(_, index) in streams"
      :key="`stream-${index}`"
      :label="$t('common.stream_url')"
    >
      <CommonWithButtonIcon icon="pi pi-trash" severity="danger" @iconClick="() => removeStream(index)">
        <InputText
          v-model="streams[index]"
          :placeholder="$t('common.stream_url')"
        />
      </CommonWithButtonIcon>
    </CommonWithLabel>

    <Button v-tooltip="$t('tournament_edit.add_stream_tooltip')" icon="pi pi-plus" @click="addStream" />
  </div>
</template>
