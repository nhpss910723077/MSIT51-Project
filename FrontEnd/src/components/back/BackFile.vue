<template>
  <div class="col-12" :class="`col-lg-${field ['ColSize']}`">
    <div class="form-group input-box input-box-file">
      <label class="control-label" :for="`field${index}`">{{ field['Name'] }}</label>
      <div class="input-box-file-img">
        <img :src="content['item'][field['FieldName']]" alt="">
      </div>
      <input type="file" class="form-control" :id="`field${index}`" :name="field['FieldName']" @change="DisplayImg" v-if="!field['ReadOnly']">
    </div>
  </div>
  <div class="col-12" v-if="field['CutCol']"></div>
</template>

<script>
export default {
  name: 'BackFile',
  props: ["index", "field", "content"],
  methods: {
    DisplayImg: function (event) {
      let file = event.target.files[0];
      if (file.type.startsWith('image/')) {
        $(event.target).siblings(".input-box-file-img").children("img").prop("src", window.URL.createObjectURL(file));
      }
    },
  }
}
</script>

<style scoped src="./css/BackComponents.css"></style>