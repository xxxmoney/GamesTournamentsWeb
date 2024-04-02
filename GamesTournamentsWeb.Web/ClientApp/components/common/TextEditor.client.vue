<template>
  <div class="container-gap">
    <BlockUI :blocked="disabled">
      <div v-if="editor" class="container-row-gap-sm">
        <Button
          :class="{ 'is-active': editor.isActive('bold') }"
          :disabled="!editor.can().chain().focus().toggleBold().run()"
          severity="secondary"
          @click="editor.chain().focus().toggleBold().run()"
        >
          <template #icon>
            <FontAwesomeIcon :icon="['fas', 'bold']" />
          </template>
        </Button>
        <Button
          :class="{ 'is-active': editor.isActive('italic') }"
          :disabled="!editor.can().chain().focus().toggleItalic().run()"
          severity="secondary"
          @click="editor.chain().focus().toggleItalic().run()"
        >
          <template #icon>
            <FontAwesomeIcon :icon="['fas', 'italic']" />
          </template>
        </Button>
        <Button
          :class="{ 'is-active': editor.isActive('strike') }"
          :disabled="!editor.can().chain().focus().toggleStrike().run()"
          severity="secondary"
          @click="editor.chain().focus().toggleStrike().run()"
        >
          <template #icon>
            <FontAwesomeIcon :icon="['fas', 'strikethrough']" />
          </template>
        </Button>
        <Button
          :class="{ 'is-active': editor.isActive('code') }"
          :disabled="!editor.can().chain().focus().toggleCode().run()"
          severity="secondary"
          @click="editor.chain().focus().toggleCode().run()"
        >
          <template #icon>
            <i class="pi pi-code" />
          </template>
        </Button>
        <!--      <Button severity="secondary" @click="editor.chain().focus().unsetAllMarks().run()">-->
        <!--        clear marks-->
        <!--      </Button>-->
        <!--      <Button severity="secondary" @click="editor.chain().focus().clearNodes().run()">-->
        <!--        clear nodes-->
        <!--      </Button>-->
        <!--      <Button-->
        <!--        :class="{ 'is-active': editor.isActive('paragraph') }"-->
        <!--        severity="secondary"-->
        <!--        @click="editor.chain().focus().setParagraph().run()"-->
        <!--      >-->
        <!--        <template #icon>-->
        <!--          <FontAwesomeIcon :icon="['fas', 'paragraph']" />-->
        <!--        </template>-->
        <!--      </Button>-->
        <!--      <Button-->
        <!--        :class="{ 'is-active': editor.isActive('heading', { level: 1 }) }"-->
        <!--        severity="secondary"-->
        <!--        @click="editor.chain().focus().toggleHeading({ level: 1 }).run()"-->
        <!--      >-->
        <!--        H1-->
        <!--      </Button>-->
        <!--      <Button-->
        <!--        :class="{ 'is-active': editor.isActive('heading', { level: 2 }) }"-->
        <!--        severity="secondary"-->
        <!--        @click="editor.chain().focus().toggleHeading({ level: 2 }).run()"-->
        <!--      >-->
        <!--        H2-->
        <!--      </Button>-->
        <!--      <Button-->
        <!--        :class="{ 'is-active': editor.isActive('heading', { level: 3 }) }"-->
        <!--        severity="secondary"-->
        <!--        @click="editor.chain().focus().toggleHeading({ level: 3 }).run()"-->
        <!--      >-->
        <!--        H3-->
        <!--      </Button>-->
        <!--      <Button-->
        <!--        :class="{ 'is-active': editor.isActive('heading', { level: 4 }) }"-->
        <!--        severity="secondary"-->
        <!--        @click="editor.chain().focus().toggleHeading({ level: 4 }).run()"-->
        <!--      >-->
        <!--        H4-->
        <!--      </Button>-->
        <!--      <Button-->
        <!--        :class="{ 'is-active': editor.isActive('heading', { level: 5 }) }"-->
        <!--        severity="secondary"-->
        <!--        @click="editor.chain().focus().toggleHeading({ level: 5 }).run()"-->
        <!--      >-->
        <!--        H5-->
        <!--      </Button>-->
        <!--      <Button-->
        <!--        :class="{ 'is-active': editor.isActive('heading', { level: 6 }) }"-->
        <!--        severity="secondary"-->
        <!--        @click="editor.chain().focus().toggleHeading({ level: 6 }).run()"-->
        <!--      >-->
        <!--        H6-->
        <!--      </Button>-->
        <!--      <Button-->
        <!--        :class="{ 'is-active': editor.isActive('bulletList') }"-->
        <!--        severity="secondary"-->
        <!--        @click="editor.chain().focus().toggleBulletList().run()"-->
        <!--      >-->
        <!--        <template #icon>-->
        <!--          <FontAwesomeIcon :icon="['fas', 'list']" />-->
        <!--        </template>-->
        <!--      </Button>-->
        <!--      <Button-->
        <!--        :class="{ 'is-active': editor.isActive('orderedList') }"-->
        <!--        severity="secondary"-->
        <!--        @click="editor.chain().focus().toggleOrderedList().run()"-->
        <!--      >-->
        <!--        <template #icon>-->
        <!--          <FontAwesomeIcon :icon="['fas', 'list-ol']" />-->
        <!--        </template>-->
        <!--      </Button>-->
        <Button
          :class="{ 'is-active': editor.isActive('codeBlock') }"
          severity="secondary"
          @click="editor.chain().focus().toggleCodeBlock().run()"
        >
          <template #icon>
            <FontAwesomeIcon :icon="['fas', 'code']" />
          </template>
        </Button>
        <!--      <Button-->
        <!--        :class="{ 'is-active': editor.isActive('blockquote') }"-->
        <!--        severity="secondary"-->
        <!--        @click="editor.chain().focus().toggleBlockquote().run()"-->
        <!--      >-->
        <!--        <template #icon>-->
        <!--          <FontAwesomeIcon :icon="['fas', 'quote-left']" />-->
        <!--        </template>-->
        <!--      </Button>-->
        <!--      <Button severity="secondary" @click="editor.chain().focus().setHorizontalRule().run()">-->
        <!--        <template #icon>-->
        <!--          <FontAwesomeIcon :icon="['fas', 'ruler-horizontal']" />-->
        <!--        </template>-->
        <!--      </Button>-->
        <!--      <Button severity="secondary" @click="editor.chain().focus().setHardBreak().run()">-->
        <!--        hard break-->
        <!--      </Button>-->
        <Button
          :disabled="!editor.can().chain().focus().undo().run()"
          severity="secondary"
          @click="editor.chain().focus().undo().run()"
        >
          <template #icon>
            <FontAwesomeIcon :icon="['fas', 'rotate-left']" />
          </template>
        </Button>
        <Button
          :disabled="!editor.can().chain().focus().redo().run()"
          severity="secondary"
          @click="editor.chain().focus().redo().run()"
        >
          <template #icon>
            <FontAwesomeIcon :icon="['fas', 'rotate-right']" />
          </template>
        </Button>
      </div>
      <TiptapEditorContent :editor="editor" />
    </BlockUI>
  </div>
</template>

<script setup>
const { modelValue } = defineProps({
  modelValue: {
    type: String,
    default: ''
  },
  disabled: {
    type: Boolean,
    default: false
  }
})

const emit = defineEmits(['update:modelValue'])
const modelValueComputed = useComputedWithEmit(modelValue, emit, 'modelValue')

const editor = useEditor({
  content: modelValueComputed.value,
  extensions: [
    TiptapStarterKit,
    TiptapBold,
    TiptapBlockquote,
    TiptapBulletList,
    TiptapOrderedList,
    TiptapListItem,
    TiptapCode,
    TiptapCodeBlock,
    TiptapDropcursor,
    TiptapItalic,
    TiptapHardBreak,
    TiptapHeading,
    TiptapLink,
    TiptapParagraph,
    TiptapStrike,
    TiptapGapcursor,
    TiptapMark
  ],
  onUpdate ({ editor }) {
    modelValueComputed.value = editor.getHTML()
  }
})

</script>
