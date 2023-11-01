<template>
  <input type="number" class="form-control back-sort" :id="`field${index}`" :name="field['FieldName']"
    v-model="content['item'][field['FieldName']]" @change="UpdateSort">
</template>

<script>
export default {
  name: 'BackSort',
  props: ["index", "field", "content"],
  methods: {
    UpdateSort: function () {
      var self = this;

      $.ajax({
        method: "POST",
        dataType: 'JSON',
        url: `${GetApiUrl()}/Back/Edit${self.$route.params.modelName}Sort/${self.content['item']['ID']}`,
        data: {
          sort: self.content['item'][self.field['FieldName']],
          __RequestVerificationToken: Cookies.get('XSRF-TOKEN'),
        },
      })
        .done(function (data) {
          document.location.reload();
        })
        .fail(function (data) {
          alert("發生錯誤");
        });
    }
  }
}
</script>

<style scoped src="./css/BackComponents.css"></style>
<style scoped>
.back-sort {
  max-width: 75px;
}
</style>