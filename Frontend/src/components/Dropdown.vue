<template>
  <div @click="onClickActivator()" class="relative" ref="activatorRef">
    <div
      class="w-full border border-black rounded px-3 py-1 overflow-hidden bg-white"
      style="height: 32px"
    >
      <div>{{ selectedItem.title }}</div>
      <div class="absolute bg-white" style="right: 12px; top: 5px">
        <i v-if="showMenue" class="fa fa-chevron-up"></i>
        <i v-else class="fa fa-chevron-down"></i>
      </div>
    </div>

    <div class="absolute w-full h-full top-0 left-0">
      <div
        class="bg-gray-300 border-gray-500 absolute overflow-y-auto w-full"
        style="top: 50px; max-height: 700px; z-index: 99"
        ref="menuRef"
      >
        <ul v-if="showMenue" class="">
          <li
            v-for="(item, index) in items"
            :key="index"
            class="hover:bg-gray-400 px-5 py-2"
            @click="onSelectItem(item)"
          >
            {{ item.title }}
          </li>
        </ul>
      </div>
    </div>
  </div>
</template>


<script setup lang="ts">
import { ref, watch, defineProps } from "vue";

const props = defineProps<{
  items: { title: string; value: any }[];
  modelValue: { title: string; value: any };
}>();

const emit = defineEmits<{
  (e: "update:modelValue", value: any): void;
}>();

const activatorRef = ref<HTMLElement | null>(null);
const menuRef = ref<HTMLElement | null>(null);
const showMenue = ref<boolean>(false);
const items = ref<{ title: string; value: any }[]>(props.items);
const selectedItem = ref<{ title: string; value: any }>(props.modelValue);

watch(
  () => props.items,
  (next) => {
    items.value = next;
  }
);
watch(
  () => props.modelValue,
  (next) => {
    selectedItem.value = next;
  }
);

/**
 * Updates selectedItem and emits and update
 * @param item user selection
 */
const onSelectItem = (item: any) => {
  selectedItem.value = item;
  emit("update:modelValue", item);
};

/**
 * Shows and hides the meanues
 */
const onClickActivator = () => {
  showMenue.value = !showMenue.value;
};

/**
 * Calculates the menu's width
 */
const getPopupWidth = () => {
  if (activatorRef.value) {
    const { left: activatorLeft, right: activatorRight } =
      activatorRef.value.getBoundingClientRect();
    return { minWidth: `${activatorRight - activatorLeft}px` };
  }
};
</script>