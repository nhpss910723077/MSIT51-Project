<template>
  <section id="newBookSlide">
    <div class="container">
      <div class="row">
        <div class="col-md-12 col-lg-8">
          <div class="top-left-container justify-content-center">
            <h1>新書上架</h1>
            <div class="swiper newbookSwiper">
              <div class="swiper-wrapper">
                <div class="swiper-slide each-card" v-for="(item, index) in newBookData">
                  <a :href="item.newBookLink">
                    <div class="card each-book">
                      <div class="card-img-top">
                        <img :src="item.Img1">
                      </div>
                      <div class="card-body book-body">
                        <a class="card-title" :title="item.Name">
                          {{ item.Name }}
                        </a>
                      </div>
                    </div>
                  </a>
                </div>
              </div>
              <div class="swiper-button-prev"></div>
              <div class="swiper-button-next"></div>
            </div>
          </div>
        </div>
        <div class="col-md-12 col-lg-4">
          <div class="top-right-container justify-content-center">
            <h1>熱搜關鍵字</h1>
            <template v-for="(item, index) in keyWordData">
              <a :href="item.keyWordLink" class="keyword-btn">#{{ item.Name }}</a>
              <br v-if="index % 2 == 1">
            </template>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
export default {
  name: 'NewBookSlide',
  data() {
    return {
      newBookData: [],
      keyWordData: []
    }
  },
  async created() {
    var self = this;

    // 取得資料
    try {
      await $.ajax({
        method: "GET",
        dataType: "JSON",
        url: `${GetApiUrl()}/Home/GetNewBookAtHome`,
      })
        .done(function (data) {
          self.newBookData = data.map((item) => {
            item.newBookLink = `/product/content/${item.pID}/${item.cID}`;
            return item;
          });
          // console.log(self.categoryData)
        })
    } catch (error) {
      console.log("發生錯誤");
    }

    // 取得資料
    try {
      await $.ajax({
        method: "GET",
        dataType: "JSON",
        url: `${GetApiUrl()}/Home/GetKeyWordAtHome`,
      })
        .done(function (data) {
          self.keyWordData = data.map((item) => {
            item.keyWordLink = `/product/lists?search=${item.Name}`;
            return item;
          });
        })
    } catch (error) {
      console.log("發生錯誤");
    }

    // 輪播
    var swiper = new Swiper(".newbookSwiper", {
      loop: true,
      navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev",
      },
      slidesPerView: 1,
      spaceBetween: 0,
      breakpoints: {
        992: {
          slidesPerView: 1,
          spaceBetween: 0
        },
        1400: {
          slidesPerView: 2,
          spaceBetween: 0
        },
        1500: {
          slidesPerView: 3,
          spaceBetween: 0
        }
      },
    });
  }
}
</script>

<style scoped src="./css/Home.css"></style>