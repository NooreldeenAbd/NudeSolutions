<template>
  <table v-if="body.length > 0" style="width: 500px" class="table-auto">
    <!-- Catacogry -->
    <thead class="bg-gray-700 text-white text-xl">
      <tr>
        <th class="">{{ catagory }}</th>
        <th class="">{{ `$ ${getTotal()}` }}</th>
        <th class=""></th>
      </tr>
    </thead>
    <!-- Items -->
    <tbody class="border-b border-b-2 border-b-black">
      <tr class="hover:bg-gray-200" v-for="(item, index) in body" :key="index">
        <td class="p-2">{{ item.name }}</td>
        <td class="p-2">{{ item.value }}</td>
        <td class="p-2">
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
  catagory: string;
  body: any;
}>();

const emit = defineEmits<{
  (e: "delete:value", value: any): void;
}>();

watch(
  () => props.catagory,
  (next) => {
    header.value = next;
  }
);

watch(
  () => props.body,
  (next) => {
    body.value = next;
  }
);

const header = ref<string>(props.catagory);
const body = ref<{ name: string; value: number }[]>(props.body);

/**
 * emits delete an item
 */
const onDeleteItem = (item: any) => {
  emit("delete:value", item);
};

const getTotal = () => {
  let total = 0;
  body.value.forEach((item) => (total += item.value));
  return total;
};
</script>