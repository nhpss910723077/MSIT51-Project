<template>
  <section id="product-suggest">
    <div class="container">
      <div class="row">
        <div class="col-12 topSale-color">
          <h1>您可能會喜歡</h1>
          <div class="swiper suggestSwiper">
            <div class="swiper-wrapper">
              <div class="swiper-slide suggestSwiper-container" v-for="(item, index) in SuggestData">
                <a :href="item.bookLink">
                  <div class="card each-book">
                    <div class="card-img-top">
                      <img class="card-img" :src="item.Img1">
                    </div>
                    <div class="card-body">
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
    </div>
  </section>
</template>

<script>
export default {
  name: 'ProductSuggest',
  data() {
    return {
      SuggestData: []
    }
  },
  async created() {
    var self = this;
    var pid = self.$route.params.id;
    var cid = self.$route.params.cid;

    // 取得資料
    try {
      await $.ajax({
        method: "GET",
        dataType: "JSON",
        url: `${GetApiUrl()}/Product/GetSuggestInProduct/${cid}`,
        data: { pID: pid, cID: cid }
      })
        .done(function (data) {
          self.SuggestData = data.map((item) => {
            item.bookLink = `/product/content/${item.pID}/${item.cID}`;
            return item;
          });
        })
    } catch (error) {
      console.log("發生錯誤");
    }

    // 輪播
    var swiper = new Swiper(".suggestSwiper", {
      loop: true,
      navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev",
      },
      slidesPerView: 1,
      spaceBetween: 0,
      breakpoints: {
        576: {
          slidesPerView: 1,
          spaceBetween: 20
        },
        768: {
          slidesPerView: 2,
          spaceBetween: 20
        },
        992: {
          slidesPerView: 3,
          spaceBetween: 30
        },
        1200: {
          slidesPerView: 4,
          spaceBetween: 40
        }
      },
    });
    var swiper = new Swiper(".userUsedBook", {});

    $(".product-toggle-title").on("click", function () {
      $(".product-container").toggle(300);
    });
  }
}
</script>

<style scoped src="./css/ProductContent.css"></style>