<template>
  <!-- Input -->
  <div
    class="mx-auto bg-gray-200 rounded shadow border py-5 m-10 flex grid grid-cols-5 gap-5"
  >
    <InputField
      class="col-start-2"
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
      :model-value="itemCategory"
      @update:model-value="onSelectCategory"
    ></Dropdown>
    <ButtonField :input-name="'Add'" @click="onAddItem"></ButtonField>
  </div>

  <!-- Table -->
  <div class="flex justify-center relative overflow-y-auto grid">
    <div v-for="(item, index) in tableData" :key="index">
      <sub-table
        :category="item.category"
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
  CategoryIds,
} from "../Services/PersonalListService";

const itemCategory = ref<{ title: string; value: number }>({
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

/**
 * Updates the current input's name
 * @param value the new name value
 */
const onUpdateName = (value: string) => {
  itemName.value = value;
};

/**
 * Updates the current input's value
 * @param value the new value ($)
 */
const onUpdateValue = (value: number) => {
  itemValue.value = value;
};

/**
 * Updates the current input's category
 * @param value the new category
 */
const onSelectCategory = (value: { title: string; value: number }) => {
  itemCategory.value = value;
};

/**
 * Removes an item from the table if delete request is
 * completed
 * @param item item to delete
 * @param categoryIndex the category of the item
 */
const onDeleteItem = async (item: InsuredItem, categoryIndex: number) => {
  const deleteResponse = await PersonalListService.DeleteItem(item.id);
  if (deleteResponse) {
    const itemIndex = tableData.value[categoryIndex].body.findIndex(
      (i) => i.id === item.id
    );
    if (itemIndex !== -1) {
      totalValue.value -= item.value;
      tableData.value[categoryIndex].body.splice(itemIndex, 1);
    }
  }
};

/**
 * Adds an item to the table if add request is
 * completed
 */
const onAddItem = async () => {
  const newItem: InsuredItem = {
    id: 0,
    name: itemName.value,
    value: itemValue.value,
    categoryId: itemCategory.value.value,
  };

  const addResponse = await PersonalListService.PostItem(newItem);
  if (addResponse) {
    newItem.id = addResponse;
    itemCategory.value;
    const index = CategoryIds.findIndex(
      (x) => x.title === itemCategory.value.title
    );
    if (index !== -1) {
      totalValue.value += newItem.value;
      tableData.value[index].body.push(newItem);
    }
  }
};
</script>
