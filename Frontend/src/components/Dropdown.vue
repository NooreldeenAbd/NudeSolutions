<template>
  <div @click="onClickActivator()" class="relative" ref="activatorRef">
    <div
      class="w-full border border-black rounded px-3 py-1 overflow-hidden"
      style="height: 32px"
    >
      <div>{{ selectedItem }}</div>
      <div class="absolute bg-bg-gray-200" style="right: 12px; top: 5px">
        <i class="fa fa-chevron-down"></i>
      </div>
    </div>

    <div class="absolute w-full h-full top-0 left-0">
      <div
        class="bg-gray-300 border-gray-500 absolute overflow-y-auto"
        :style="getPopupWidth()"
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
            {{ item }}
          </li>
        </ul>
      </div>
    </div>
  </div>
</template>


<script setup lang="ts">
import { ref, watch, defineProps } from "vue";

const props = defineProps<{
  items: any[];
  modelValue: any;
}>();

const emit = defineEmits<{
  (e: "update:modelValue", value: any): void;
}>();

const activatorRef = ref<HTMLElement | null>(null);
const menuRef = ref<HTMLElement | null>(null);
const showMenue = ref<boolean>(false);
const items = ref<any[]>(props.items);
const selectedItem = ref<any>(props.modelValue);

watch(
  () => props.modelValue,
  (next) => {
    items.value = next;
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