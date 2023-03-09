<template>
  <!-- Input -->
  <div
    class="container mx-auto bg-gray-200 rounded shadow border p-8 m-10 flex grid grid-cols-4 gap-5"
  >
    <InputField
      :input-id="'name'"
      :input-name="'name'"
      :place-holder="'Item name'"
      :input-type="'text'"
      :model-value="itemName"
    ></InputField>
    <InputField
      :input-id="'price'"
      :input-name="'price'"
      :place-holder="'Value ($)'"
      :input-type="'number'"
      :model-value="itemValue"
    ></InputField>
    <Dropdown
      :items="['Electronics', 'Clothing', 'Kitchen', 'Other']"
      :model-value="itemCatagory"
    ></Dropdown>
    <ButtonField :input-name="'Add'"></ButtonField>
  </div>

  <!-- Table -->
  <div class="flex items-center justify-center overflow-y-auto">
    <sub-table
      :catagory="'hello'"
      :body="[{ name: 'Name', value: 2200 }]"
    ></sub-table>
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref } from "vue";
import Dropdown from "../components/Dropdown.vue";
import InputField from "../components/InputField.vue";
import ButtonField from "../components/ButtonField.vue";
import SubTable from "../components/SubTable.vue";
import PersonalListService, {
  catagories,
  InsuredItem,
} from "../Services/PersonalListService";

const itemCatagory = ref<string>("");
const itemName = ref<string>("");
const itemValue = ref<number>();

onMounted(async () => {
  PersonalListService.GetList();
});
</script>
