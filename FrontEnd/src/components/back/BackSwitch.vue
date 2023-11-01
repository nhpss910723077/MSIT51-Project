<template>
  <div class="col-12" :class="`col-lg-${field['ColSize']}`">
    <div class="form-group input-box">
      <label class="control-label" :for="`field${index}`">{{ field['Name'] }}</label>
      <div class="form-check form-switch back-switch">
        <input type="checkbox" class="form-check-input" value=true :name="field['FieldName']" role="switch"
          v-model="content['item'][field['FieldName']]">
      </div>
    </div>
  </div>
  <div class="col-12" v-if="field['CutCol']"></div>
</template>

<script>
export default {
  name: 'BackSwitch',
  props: ["index", "field", "content"]
}
</script>

<style scoped src="./css/BackComponents.css"></style>
<style scoped>
.back-switch.form-check.form-switch {
  min-height: 25px;
}

.back-switch.form-check.form-switch .form-check-input {
  width: 55px;
  height: 25px;
  cursor: pointer;
}
</style>