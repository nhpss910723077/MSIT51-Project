<template>
  <div class="col-md-12 col-lg-4" id="suggestBook">
    <div class="second-left-container justify-content-center">
      <h2>今日為您推薦</h2>
      <div class="swiper randomBook">
        <div class="swiper-wrapper randomBook-container">
          <div class="swiper-slide" v-for="(item, index) in suggestBookData">
            <a :href="item.suggestBookLink"><img :src="item.Img1"></a>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'SuggestBook',
  data() {
    return {
      suggestBookData: [],
    }
  },
  async created() {
    var self = this;

    // 取得資料
    try {
      await $.ajax({
        method: "GET",
        dataType: "JSON",
        url: `${GetApiUrl()}/Home/GetSuggestBookAtHome`,
      })
        .done(function (data) {
          self.suggestBookData = data.map((item) => {
            item.suggestBookLink = `/product/content/${item.pID}/${item.cID}`;
            return item;
          });
        })
    } catch (error) {
      console.log("發生錯誤");
    }

    // 輪播
    var swiper = new Swiper(".randomBook", {
      effect: "cards",
      grabCursor: true,
    });
  }
}
</script>

<style scoped src="./css/Home.css"></style>