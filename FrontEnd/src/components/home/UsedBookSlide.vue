<template>
  <div id="usedBookSlide" class="second-right-container justify-content-center">
    <h1>熱門徵求二手書</h1>
    <div class="swiper newbookSwiper">
      <div class="swiper-wrapper">
        <div class="swiper-slide each-card" v-for="(item, index) in usedBookData">

          <a :href="item.usedBookLink">
            <div class="card each-book">
              <div class="card-img-top">
                <img :src="item.Img1">
              </div>
              <div class="card-body book-body">
                <a class="card-title" :title="item.Name">{{ item.Name }}</a>
              </div>
            </div>
          </a>
        </div>
      </div>
      <div class="swiper-button-prev"></div>
      <div class="swiper-button-next"></div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'UsedBookSlide',
  data() {
    return {
      usedBookData: []
    }
  },
  async created() {
    var self = this;

    // 取得資料
    try {
      $.ajax({
        method: "GET",
        dataType: "JSON",
        url: `${GetApiUrl()}/Home/GetUserSeekAtHome`,
      })
        .done(function (data) {
          self.usedBookData = data.map((item) => {
            item.usedBookLink = `/product/content/${item.pID}/${item.cID}`;
            return item;
          });
        })
    } catch (error) {
      console.log("發生錯誤");
    }
  }
}
</script>

<style scoped src="./css/Home.css"></style>