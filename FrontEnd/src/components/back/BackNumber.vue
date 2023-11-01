<template>
  <div class="col-12" :class="`col-lg-${field['ColSize']}`">
    <div class="form-group input-box">
      <label class="control-label" :for="`field${index}`">{{ field['Name'] }}</label>
      <input type="number" class="form-control" :id="`field${index}`" :name="field['FieldName']"
        v-model="content['item'][field['FieldName']]" :readonly="field['ReadOnly']" :disabled="field['ReadOnly']">
    </div>
  </div>
  <div class="col-12" v-if="field['CutCol']"></div>
</template>

<script>
export default {
  name: 'BackNumber',
  props: ["index", "field", "content"]
}
</script>

<style scoped src="./css/BackComponents.css"></style>