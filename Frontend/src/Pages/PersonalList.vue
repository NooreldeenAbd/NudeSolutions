<template>
  <div
    class="container mx-auto bg-gray-200 rounded-xl shadow border p-8 m-10 flex grid grid-cols-4 gap-5"
  >
    <Dropdown :items="[1, 2, 3]" :model-value="dd"></Dropdown>
    <InputField
      :input-id="'price'"
      :input-name="'price'"
      :placeHolder="'Value'"
      :inputType="'number'"
      :model-value="price"
    ></InputField>
    <Buttoninput></Buttoninput>
  </div>
</template>

<script setup lang="ts">
import { ref } from "vue";
import Dropdown from "../components/Dropdown.vue";
import InputField from "../components/InputField.vue";
import Buttoninput from "../components/Buttoninput.vue";
const dd = ref<number>(1);
const price = ref<number>();
</script>
