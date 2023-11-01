<template>
  <section id="topSlide">
    <div class="swiper topSwiper">
      <div class="swiper-wrapper top-slide-container">
        <div class="swiper-slide" v-for="(item, index) in topBanner">
          <a class="top-swiper-link" :href="item.Link" target="_blank">
            <img class="top-swiper-img" :src="item.Img1">
          </a>
        </div>
      </div>
      <div class="swiper-pagination"></div>
    </div>
  </section>
</template>

<script>
export default {
  name: 'TopSlide',
  data() {
    return {
      topBanner: [],
    }
  },
  async created() {
    var self = this;

    // 取得資料
    try {
      await $.ajax({
        method: "GET",
        dataType: "JSON",
        url: `${GetApiUrl()}/Home/GetBannerAtHome`,
      })
        .done(function (data) {
          self.topBanner = data.map((item) => {
            return item;
          });
        })
    } catch (error) {
      console.log("發生錯誤");
    }

    // 輪播
    var swiper = new Swiper(".topSwiper", {
      loop: true,
      pagination: {
        el: ".swiper-pagination",
        dynamicBullets: true,
        clickable: true,
      },
      autoplay: {
        delay: 5000,
        disableOnInteraction: false,
      },
    });
  }
}
</script>

<style scoped src="./css/Home.css"></style>