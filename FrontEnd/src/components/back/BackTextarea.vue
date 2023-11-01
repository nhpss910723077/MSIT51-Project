<template>
  <div class="col-12" :class="`col-lg-${field['ColSize']}`">
    <div class="form-group input-box">
      <label class="control-label" :for="`field${index}`">{{ field['Name'] }}</label>
      <textarea :name="field['FieldName']" class="form-control" :id="`field${index}`"
        v-model="content['item'][field['FieldName']]" rows="10" :readonly="field['ReadOnly']" :disabled="field['ReadOnly']"></textarea>
    </div>
  </div>
  <div class="col-12" v-if="field['CutCol']"></div>
</template>

<script>
export default {
  name: 'BackTextarea',
  props: ["index", "field", "content"]
}
</script>

<style scoped src="./css/BackComponents.css"></style>