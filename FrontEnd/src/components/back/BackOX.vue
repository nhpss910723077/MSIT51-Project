<template>
  <div class="back-enable">
    <template v-if="content['item'][field['FieldName']]">
      <i class="fa-solid fa-o"></i>
    </template>
    <template v-else>
      <i class="fa-solid fa-x"></i>
    </template>
  </div>
</template>

<script>
export default {
  name: 'BackText',
  props: ["index", "field", "content"]
}
</script>

<style scoped>
.back-enable .fa-o {
  color: green;
  font-size: 30px;
  font-weight: bold;
}

.back-enable .fa-x {
  color: red;
  font-size: 30px;
  font-weight: bold;
}
</style>