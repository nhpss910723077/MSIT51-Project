<template>
  <section id="newsSlide">
    <h1>最新消息</h1>
    <div class="swiper news-slide">
      <div class="swiper-wrapper">
        <div class="swiper-slide news-img-container" v-for="(item, index) in newsSlideData">
          <a :href="item.newsSlideLink">
            <img :src="item.Img1" />
          </a>
        </div>
      </div>
      <div class="swiper-pagination"></div>
    </div>
  </section>
</template>

<script>
export default {
  name: 'NewsSlide',
  data() {
    return {
      newsSlideData: [],
    }
  },
  async created() {
    var self = this;

    // 取得資料
    try {
      await $.ajax({
        method: "GET",
        dataType: "JSON",
        url: `${GetApiUrl()}/Home/GetNewsAtHome`,
      })
        .done(function (data) {
          self.newsSlideData = data.map((item) => {
            item.newsSlideLink = `/news/content/${item.ID}`;
            return item;
          });
        })
    } catch (error) {
      console.log("發生錯誤");
    }

    // 輪播
    var swiper = new Swiper(".news-slide", {
      effect: "coverflow",
      grabCursor: true,
      loop: true,
      speed: 800,
      centeredSlides: true,
      slidesPerView: "auto",
      coverflowEffect: {
        rotate: 50,
        stretch: 0,
        depth: 100,
        modifier: 1,
        slideShadows: true,
      },
      pagination: {
        el: ".swiper-pagination",
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
