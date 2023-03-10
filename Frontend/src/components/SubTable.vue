<template>
  <table v-if="body.length > 0" style="width: 500px" class="table-fixed">
    <!-- Category -->
    <thead class="bg-gray-700 text-white text-lg">
      <tr>
        <th class="text-left">{{ category }}</th>
        <th class="text-left">{{ `Sub total: $ ${getTotal()}` }}</th>
        <th class="text-left"></th>
      </tr>
    </thead>
    <!-- Items -->
    <tbody class="border-b border-b-2 border-b-black">
      <tr class="hover:bg-gray-200" v-for="(item, index) in body" :key="index">
        <td class="text-left">{{ item.name }}</td>
        <td class="text-left">{{ item.value }}</td>
        <td class="">
          <i
            class="fa fa-trash hover:cursor-pointer hover:text-red-500"
            @click="onDeleteItem(item)"
          ></i>
        </td>
      </tr>
    </tbody>
  </table>
</template>
      
      
    <script setup lang="ts">
import { ref, defineProps, watch } from "vue";

const props = defineProps<{
  category: string;
  body: any;
}>();

const emit = defineEmits<{
  (e: "delete:value", value: any): void;
}>();

watch(
  () => props.category,
  (next) => {
    header.value = next;
  }
);

watch(
  () => props.body,
  (next) => {
    body.value = next;
  },
  { deep: true }
);

const header = ref<string>(props.category);
const body = ref<{ name: string; value: number }[]>(props.body);

/**
 * emits delete an item
 */
const onDeleteItem = (item: any) => {
  emit("delete:value", item);
};

/**
 * Gets the total value of the items in teh suitable
 */
const getTotal = () => {
  let total = 0;
  body.value.forEach((item) => (total += item.value));
  return total;
};
</script>