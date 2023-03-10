<template>
  <!-- Input -->
  <div
    class="mx-auto bg-gray-200 rounded shadow border py-5 m-10 flex grid grid-cols-4 gap-5"
  >
    <InputField
      :input-id="'name'"
      :input-name="'name'"
      :place-holder="'Item name'"
      :input-type="'text'"
      :model-value="itemName"
      @update:model-value="onUpdateName"
    ></InputField>
    <InputField
      :input-id="'price'"
      :input-name="'price'"
      :place-holder="'Value ($)'"
      :input-type="'number'"
      :model-value="itemValue"
      @update:model-value="onUpdateValue"
    ></InputField>
    <Dropdown
      :items="[
        { title: 'Electronics', value: 1 },
        { title: 'Clothing', value: 2 },
        { title: 'Kitchen', value: 3 },
      ]"
      :model-value="itemCatagory"
      @update:model-value="onSelectCatagory"
    ></Dropdown>
    <ButtonField :input-name="'Add'" @click="onAddItem"></ButtonField>
  </div>

  <!-- Table -->
  <div class="flex justify-center relative overflow-y-auto grid">
    <div v-for="(item, index) in tableData" :key="index">
      <sub-table
        :catagory="item.catagory"
        :body="item.body"
        @delete:value="(item) => onDeleteItem(item, index)"
      ></sub-table>
    </div>
    <table style="width: 500px" class="table-fixed">
      <thead class="bg-green-700 text-white text-lg">
        <tr>
          <th class="text-left">Total</th>
          <th class="text-left">{{ `$ ${totalValue}` }}</th>
          <th class="text-left"></th>
        </tr>
      </thead>
    </table>
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref } from "vue";
import Dropdown from "../components/Dropdown.vue";
import InputField from "../components/InputField.vue";
import ButtonField from "../components/ButtonField.vue";
import SubTable from "../components/SubTable.vue";
import PersonalListService, {
  InsuredItem,
  TableData,
  CatagoryIds,
} from "../Services/PersonalListService";

const itemCatagory = ref<{ title: string; value: number }>({
  title: "Electronics",
  value: 1,
});
const itemName = ref<string>("");
const itemValue = ref<number>(0);
const tableData = ref<TableData[]>([]);
const totalValue = ref<number>(0);

onMounted(async () => {
  let total = 0;
  const tableDataResponse = await PersonalListService.GetList();
  if (tableDataResponse) {
    tableData.value = tableDataResponse;
    tableData.value.forEach((subTable) => {
      subTable.body.forEach((entry) => (total += entry.value));
    });
  }
  totalValue.value = total;
});

const onUpdateName = (value: string) => {
  itemName.value = value;
};

const onUpdateValue = (value: number) => {
  itemValue.value = value;
};

const onSelectCatagory = (value: { title: string; value: number }) => {
  itemCatagory.value = value;
};

const onDeleteItem = async (item: InsuredItem, catagoryIndex: number) => {
  const deleteResponse = await PersonalListService.DeleteItem(item.id);
  if (deleteResponse) {
    const itemIndex = tableData.value[catagoryIndex].body.findIndex(
      (i) => i.id === item.id
    );
    if (itemIndex !== -1) {
      totalValue.value -= item.value;
      tableData.value[catagoryIndex].body.splice(itemIndex, 1);
    }
  }
};

const onAddItem = async () => {
  const newItem: InsuredItem = {
    id: 0,
    name: itemName.value,
    value: itemValue.value,
    catagoryId: itemCatagory.value.value,
  };

  const addResponse = await PersonalListService.PostItem(newItem);
  if (addResponse) {
    newItem.id = addResponse;
    itemCatagory.value;
    const index = CatagoryIds.findIndex(
      (x) => x.title === itemCatagory.value.title
    );
    if (index !== -1) {
      totalValue.value += newItem.value;
      tableData.value[index].body.push(newItem);
    }
  }
};
</script>
