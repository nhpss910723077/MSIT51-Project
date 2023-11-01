<template>
  <div id="subHeaderSlide" class="swiper">
    <div class="swiper-wrapper">
      <div class="swiper-slide banner" v-for="(item, index) in subhead">
        <a :href="item.Link" target="_blank">
          <img :src="`/images/subhead1.jpg`">
        </a>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'TopBanner',
  data() {
    return {
      subhead: []
    }
  },
  async created() {
    var self = this;

    // 取得資料
    try {
      await $.ajax({
        method: "GET",
        dataType: "JSON",
        url: `${GetApiUrl()}/Home/GetSubHeadAtHome`,
      })
        .done(function (data) {
          self.subhead = data.map((item) => {
            return item;
          });
          // console.log(self.categoryData)
        })
    } catch (error) {
      console.log("發生錯誤");
    }

    // 輪播
    var swiper = new Swiper("#subHeaderSlide", {
      loop: true,
      effect: 'fade',
      fadeEffect: {
        crossFade: true
      },
      autoplay: {
        delay: 5000,
        disableOnInteraction: false,
      },
    });
  }
}
</script>