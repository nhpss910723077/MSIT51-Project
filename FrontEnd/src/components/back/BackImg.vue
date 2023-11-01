<template>
  <img :src="content['item'][field['FieldName']]" alt="">
</template>

<script>
export default {
  name: 'BackImg',
  props: ["index", "field", "content"]
}
</script>

<style scoped src="./css/BackComponents.css"></style>
<style scoped>
.input-box-file img{
    max-width: 150px;
}

.input-box-file-img{
    display: flex;
    justify-content: start;
    align-items: end;
    width: 100%;
    flex-wrap: wrap;
}

.input-box-file-img img{
    margin: 0 10px 10px 0;
}
</style>