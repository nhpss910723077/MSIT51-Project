<template>
  <div class="col-12" :class="`col-lg-${field['ColSize']}`">
    <div class="form-group">
      <label class="control-label">搜尋ISBN</label>
      <div class="search-wrap">
        <input type="text" class="form-control" id="searchISBN">
        <button type="button" class="btn btn-primary" @click="getISBN()">搜尋</button>
      </div>
    </div>
  </div>

  <div class="col-12" :class="`col-lg-6`">
    <div class="form-group input-box">
      <label class="control-label">ISBN10</label>
      <input type="text" class="form-control" name="ISBN10" :value="content['item']['ISBN10']" readonly>
    </div>
  </div>

  <div class="col-12" :class="`col-lg-6`">
    <div class="form-group input-box">
      <label class="control-label">ISBN13</label>
      <input type="text" class="form-control" name="ISBN13" :value="content['item']['ISBN13']" readonly>
    </div>
  </div>
  <div class="col-12"></div>
</template>

<script>
export default {
  name: 'BackInput',
  props: ["index", "field", "content"],
  methods: {
    getISBN: function () {
      // 9571374946;
      let ISBN = $("#searchISBN").val();
      $.ajax({
        method: "GET",
        dataType: 'JSON',
        url: `https://www.googleapis.com/books/v1/volumes?q=isbn:${ISBN}&qt=lang_switch&lang=zh-tw`,
      }).done(function (data) {
        if (data.totalItems != 1) {
          Swal.fire({
            title: "查無此書籍！",
            icon: "error",
            timer: 2000,
            showConfirmButton: false,
          });
        } else {
          let ISBNData = data.items[0].volumeInfo.industryIdentifiers;
          for (let item of ISBNData) {
            if (item.type == "ISBN_10") {
              $("input[name='ISBN10']").val(item.identifier);
            } else if (item.type == "ISBN_13") {
              $("input[name='ISBN13']").val(item.identifier);
            }
          }
        }
      });
    }
  },
  mounted() {
    var self = this;



  }
}
</script>

<style scoped src="./css/BackComponents.css"></style>
<style scoped>
.search-wrap {
  display: flex;
  justify-content: flex-start;
  align-items: center;
}

#searchISBN {
  width: 300px;
  margin-right: 25px;
}
</style>