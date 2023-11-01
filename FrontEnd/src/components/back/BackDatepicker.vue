<template>
  <div class="col-12" :class="`col-lg-${field['ColSize']}`">
    <div class="form-group input-box">
      <label class="control-label" :for="`field${index}`">{{ field['Name'] }}</label>
      <input type="text" class="form-control f-hasDatepicker" :id="`field${index}`" :name="field['FieldName']"
        :value="GetValue" :readonly="field['ReadOnly']" :disabled="field['ReadOnly']">
    </div>
  </div>
  <div class="col-12" v-if="field['CutCol']"></div>
</template>

<script>
export default {
  name: 'BackDatepicker',
  props: ["index", "field", "content"],
  computed: {
    GetValue: function () {
      let value = this.content['item'][this.field['FieldName']];
      if (value && value != "0001-01-01T00:00:00") {
        return value.split('T')[0];
      }
      else {
        return "";
      }
    }
  },
  mounted() {
    var self = this;

    $(`#field${self.index}`).datepicker({
      dateFormat: "yy-mm-dd",
      regional: "zh-TW",
    });
  }
}
</script>

<style scoped src="./css/BackComponents.css"></style>