<template>
  <div class="col-12" :class="`col-lg-${field['ColSize']}`">
    <div class="form-group input-box">
      <label class="control-label" :for="`field${index}`">{{ field['Name'] }}</label>
      <input type="text" class="form-control" :id="`field${index}`" :name="field['FieldName']"
        :value="$route.query[field['FieldName']]" @change="SearchSubmit()">
    </div>
  </div>
  <div class="col-12" v-if="field['CutCol']"></div>
</template>

<script>
export default {
  name: 'BackSearchInput',
  props: ["index", "field", "content"],
  methods: {
    SearchSubmit: function () {
      let search = new FormData($('#search')[0]);
      let href = this.$route.path;
      for (const [key, value] of search.entries()) {
        if(href.indexOf("?") == -1){
          href += "?";
        } else {
          href += "&";
        }
        href += `${key}=${value}`;
      }
      this.$router.push(href);
    }
  }
}
</script>

<style scoped src="./css/BackComponents.css"></style>