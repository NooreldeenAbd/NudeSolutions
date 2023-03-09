<template>
  <div class="w-full">
    <button
      class="bg-transparent hover:bg-blue-500 text-blue-700 font-semibold hover:text-white px-4 border border-blue-500 hover:border-transparent rounded"
      style="height: 32px"
      @click="onClick()"
    >
      {{ inputName }}
    </button>
  </div>
</template>
    
    
  <script setup lang="ts">
import { ref, defineProps } from "vue";

const props = defineProps<{
  inputName: string;
}>();

const emit = defineEmits<{
  (e: "click"): void;
}>();

const inputName = ref<any>(props.inputName);

/**
 * Emits click
 */
const onClick = () => {
  emit("click");
};
</script>