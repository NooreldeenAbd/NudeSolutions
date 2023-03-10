<template>
  <div class="w-full">
    <input
      class="w-full border border-black rounded px-3 py-1"
      style="height: 32px"
      :id="inputId"
      :name="inputName"
      :placeholder="placeHolder"
      :type="inputType ? inputType : 'text'"
      v-model="inputValue"
      @input="onModelValueUpdate"
      @change="onModelValueUpdate"
      @click="onClick"
    />
  </div>
</template>
  
  
<script setup lang="ts">
import { ref, watch, defineProps } from "vue";

const props = defineProps<{
  modelValue: any;
  placeHolder: string;
  inputId: string;
  inputName: string;
  inputType: string;
}>();

const emit = defineEmits<{
  (e: "update:modelValue", value: any): void;
  (e: "click"): void;
  (e: "blur"): void;
}>();

const inputValue = ref<any>(props.modelValue);

watch(
  () => props.modelValue,
  (next) => {
    inputValue.value = next;
  }
);

/**
 * Emits modelValue
 */
const onModelValueUpdate = () => {
  emit("update:modelValue", inputValue.value);
};

/**
 * Emits click
 */
const onClick = () => {
  emit("click");
};
</script>