<template>
  <div class="col-12" :class="`col-lg-${field['ColSize']}`">
    <div class="form-group input-box">
      <label class="control-label" :for="`field${index}`">{{ field['Name'] }}</label>
      <select :name="field['FieldName']" :id="`field${index}`" class="form-select"
        v-model="content['item'][field['FieldName']]" :readonly="field['ReadOnly']" :disabled="field['ReadOnly']">
        <option value="">請選擇</option>
        <option v-for="(item, index) in content[field['RefTable']]" :value="item[field['RefKey']]">{{ item[field['RefField']] }}
        </option>
      </select>
    </div>
  </div>
  <div class="col-12" v-if="field['CutCol']"></div>
</template>

<script>
export default {
  name: 'BackSelect',
  props: ["index", "field", "content"],
  mounted() {
    var self = this;
    
    // 空或0改成空字串
    if (self.$route.name === "backCreate" && !this.content['item'][this.field['FieldName']]) {
      this.content['item'][this.field['FieldName']] = "";
    }
  }
}
</script>

<style scoped src="./css/BackComponents.css"></style>