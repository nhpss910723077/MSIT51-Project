<template>
  <section id="productContentData">
    <div class="container">
      <div class="row">
        <div class="col-ms-12 col-lg-4">
          <div>
            <div class="container">
              <div class="row">
                <div class="col-12 product-img-container">
                  <div class="col-12 product-img">
                    <img :src="productData.Img1" alt="">
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="col-ms-12 col-lg-5">
          <div class="product-content">
            <h1>{{ productData.Name }}</h1>
            <h2>作　者：{{ productData.Author }}</h2>
            <h2>譯　者：{{ productData.Translator }}</h2>
            <h2>出版社：{{ productData.Publisher }}</h2>
            <h2>出版日：{{ productData.PublishDate }}</h2>
            <h2>定　價：<s>NT$ {{ productData.ListPrice }}</s>元</h2>
            <h2>優惠價：<span class="sale-price">NT$ {{ productData.SalePrice }}元</span></h2>
            <h2 class="rating-container">評　分：
              <template v-if="starTrue">
                <p class="rating">
                  <i v-for="star in filledStarsAverage" class="fa-solid fa-star"></i>
                  <i v-for="star in emptyStarsAverage" class="fa-regular fa-star"></i>
                </p>
                <span>
                  {{ averageRating }}
                </span>
              </template>
              <template v-else>
                <p>目前還沒有人為此評分</p>
              </template>
            </h2>
          </div>
        </div>
        <div class="col-ms-12 col-lg-3 product-button-container">
          <div class="product-button">
            <p><button class="btn" @click="addToCart(productData)">加入購物車</button></p>
            <p><button class="btn" @click="changeToUserUsed()">二　手　書</button></p>
            <p><button class="btn" @click="addToLike(productData)">喜歡 ♥ 收藏</button></p>
          </div>
        </div>

      </div>
    </div>

    <section>
      <div class="container">
        <div class="row ">
          <div class="col-ms-12 col-lg-12 product-all-container">
            <div class="product-toggle-title">選單</div>
            <div class="nav nav-tabs product-container" id="nav-tab" role="tablist">
              <button class="nav-link active" id="nav-content-tab" data-bs-toggle="tab" data-bs-target="#nav-content"
                type="button" role="tab" aria-controls="nav-content" aria-selected="true">
                內容簡介
              </button>
              <button class="nav-link" id="nav-author-tab" data-bs-toggle="tab" data-bs-target="#nav-author" type="button"
                role="tab" aria-controls="nav-author" aria-selected="false">
                作者介紹
              </button>
              <button class="nav-link" id="nav-user-comment-tab" data-bs-toggle="tab" data-bs-target="#nav-user-comment"
                type="button" role="tab" aria-controls="nav-user-comment" aria-selected="false">
                讀者書評
              </button>
              <button class="nav-link" id="nav-specification-tab" data-bs-toggle="tab" data-bs-target="#nav-specification"
                type="button" role="tab" aria-controls="nav-specification" aria-selected="false">
                書籍規格
              </button>
              <button class="nav-link" id="nav-reusedbook-tab" data-bs-toggle="tab" data-bs-target="#nav-reusedbook"
                type="button" role="tab" aria-controls="nav-reusedbook" aria-selected="false">
                二 手 書
              </button>
              <button class="nav-link" id="nav-cartNote-tab" data-bs-toggle="tab" data-bs-target="#nav-cartNote"
                type="button" role="tab" aria-controls="nav-cartNote" aria-selected="false">
                購物須知
              </button>
            </div>
            <div class="tab-content product-content-container" id="nav-tabContent">
              <div class="tab-pane fade show active" id="nav-content" role="tabpanel" aria-labelledby="nav-content-tab">
                <p>{{ productData.Content }}</p>
              </div>
              <div class="tab-pane fade" id="nav-author" role="tabpanel" aria-labelledby="nav-author-tab">
                <p>{{ productData.AuthorContent }}</p>
              </div>
              <div class="tab-pane fade" id="nav-user-comment" role="tabpanel" aria-labelledby="nav-user-comment-tab">
                <template v-if="comment.length > 0">
                  <div class="user-comment-content" v-for="(item, index) in comment">
                    <p>讀者：{{ item.NickName }}</p>
                    <p class="rating">
                      <i v-for="star in filledStars(item.Score)" class="fa-solid fa-star"></i>
                      <i v-for="star in emptyStars(item.Score)" class="fa-regular fa-star"></i>
                    </p>
                    <p>{{ item.ReviewTitle }}</p>
                    <p>{{ item.Review }}</p>
                    <hr>
                  </div>
                </template>
                <template v-else>
                  <p>
                    目前還沒有人為此評價
                  </p>
                </template>
              </div>
              <div class="tab-pane fade" id="nav-specification" role="tabpanel" aria-labelledby="nav-specification-tab">
                <p>{{ productData.Specification }}</p>
              </div>
              <div class="tab-pane fade reusedbook-container" id="nav-reusedbook" role="tabpanel"
                aria-labelledby="nav-reusedbook-tab">
                <div class="container">
                  <div class="row">
                    <div class="col-ms-12 col-lg-6 reused-button">
                      <template v-if="saleAverage > 0">
                        <p>平均二手價<span>{{ saleAverage }}</span>元</p>
                      </template>
                      <button @click="needBookBtn(productData.ISBN13)">
                        我需要二手書
                      </button>
                    </div>
                    <div class="col-ms-12 col-lg-6 reused-button">
                      <template v-if="needAverage > 0">
                        <p>平均徵求價<span>{{ needAverage }}</span>元</p>
                      </template>
                      <button @click="saleBookBtn()">
                        我要賣二手書
                      </button>
                    </div>
                    <hr>
                    <div class="col-lg-12">
                      <div class="container">
                        <div class="table-responsive reused-table-container">
                          <div class="d-flex reused-title">
                            <h2>銷售中的二手書</h2>
                            <div>
                              <select name="" id="" v-model="productSelect" @change="dataSort">
                                <option>價格低到高</option>
                                <option>書況全新優先</option>
                                <option>上架日期新到舊</option>
                              </select>
                            </div>
                          </div>

                          <div id="" class="container rwd-content-data">
                            <div class="row" v-for="(item, index) in displayedData">
                              <div class="col-5 rwd-used-left">
                                <span class="rwd-user-img" type="button" data-bs-toggle="modal"
                                  :data-bs-target="'#usedModalRWD' + index">
                                  <img :src="item.Img1">
                                </span>
                                <div class="modal fade" :id="'usedModalRWD' + index" tabindex="-1"
                                  aria-labelledby="usedModalLabel" aria-hidden="true">
                                  <div class="modal-dialog">
                                    <div class="modal-content">
                                      <div class="modal-header">
                                        <a id="used-close" type="button" class="btn-close" data-bs-dismiss="modal"
                                          aria-label="Close"></a>
                                      </div>
                                      <div class="modal-body">
                                        <div class="swiper userUsedBook">
                                          <div class="swiper-wrapper">
                                            <div class="swiper-slide used-slide">
                                              <img :src="item.Img1">

                                              <img :src="item.Img2">

                                              <img :src="item.Img3">
                                            </div>
                                          </div>
                                        </div>
                                      </div>
                                    </div>
                                  </div>
                                </div>
                              </div>
                              <div class="col-7 rwd-content-container">
                                <div>編號：{{ index + 1 }}</div>
                                <div>價格：NT${{ item.SalePrice }}</div>
                                <div>書況：{{ item.BookStatus }}</div>
                                <div>賣家：{{ item.NickName }}</div>
                                <div class="col-6">上架日期：
                                  <div>
                                    {{ item.Date.split('T')[0] }}
                                  </div>
                                </div>
                                <div class="rwd-used-cart">
                                  <button @click="addToCart(item)">
                                    加入購物車
                                  </button>
                                </div>
                              </div>
                              <hr>
                            </div>
                          </div>


                          <table class="table table-hover used-table">
                            <thead class="reused-thead">
                              <tr>
                                <th>編 號</th>
                                <th>價 格</th>
                                <th>書 況</th>
                                <th>圖 片</th>
                                <th>賣 家</th>
                                <th>上架日期</th>
                              </tr>
                            </thead>
                            <tbody class="reused-tbody" v-for="(item, index) in displayedData">
                              <tr>
                                <td>{{ index + 1 }}</td>
                                <td>NT$ {{ item.SalePrice }}</td>
                                <td>{{ item.BookStatus }}</td>
                                <td>
                                  <span type="button" data-bs-toggle="modal" :data-bs-target="'#usedModal' + index">
                                    <img class="reused-book" :src="item.Img1">
                                  </span>
                                  <div class="modal fade" :id="'usedModal' + index" tabindex="-1"
                                    aria-labelledby="usedModalLabel" aria-hidden="true">
                                    <div class="modal-dialog">
                                      <div class="modal-content">
                                        <div class="modal-header">
                                          <button id="used-close" type="button" class="btn-close" data-bs-dismiss="modal"
                                            aria-label="Close"></button>
                                        </div>
                                        <div class="modal-body">
                                          <div class="swiper userUsedBook">
                                            <div class="swiper-wrapper">
                                              <div class="swiper-slide used-slide">
                                                <img :src="item.Img1">

                                                <img :src="item.Img2">

                                                <img :src="item.Img3">
                                              </div>
                                            </div>
                                          </div>
                                        </div>
                                      </div>
                                    </div>
                                  </div>
                                </td>
                                <td>{{ item.NickName }}</td>
                                <td>{{ item.Date.split('T')[0] }}</td>
                                <td>
                                  <button @click="addToCart(item)">
                                    加入購物車
                                  </button>
                                </td>
                              </tr>
                            </tbody>
                          </table>
                          <div class="col-lg-12">
                            <div class="all-data" v-if="allDataLoaded">
                              已是全部二手書
                            </div>
                            <button @click="loadMore" v-else>
                              More
                            </button>
                          </div>
                        </div>
                      </div>
                    </div>

                  </div>
                </div>
              </div>
              <div class="tab-pane fade" id="nav-cartNote" role="tabpanel" aria-labelledby="nav-cartNote-tab">
                <p>{{ cartNote }}</p>
              </div>
            </div>
          </div>
        </div>
      </div>

    </section>
  </section>
</template>

<script>
export default {
  name: 'ProductContentData',
  props: ["productData"],
  data() {
    return {
      comment: [],
      cartNote: `
                        ■寄送時間
                        預計訂單成立後 7 個工作天內送達不含週六日及國定假日。
                        如廠商有約定日將於約定日期內送達，約定日期需於訂單成立後 14天內。
                        ■送貨方式
                        透過宅配或是郵局送達。
                        消費者訂購之商品若經配送兩次無法送達，
                        再經本公司以電話與 E-mail 均無法聯繫逾三天者，
                        本公司將取消該筆訂單，並且全額退款。
                        ■送貨範圍
                        限台灣本島地區。注意！收件地址請勿為郵政信箱。
                        若有台灣本島以外地區送貨需求，收貨人地址請填台灣本島親友的地址。`,
      reusedData: [],
      productSelect: '價格低到高',
      displayedData: [],
      pageSize: 5,
      currentIndex: 0,
      averageRating: "",
      maxStars: 5,
      starTrue: true,
      saleAverage: 150,
      needAverage: 100,
    }
  },
  computed: {
    allDataLoaded() {
      return this.currentIndex >= this.reusedData.length;
    },
    filledStarsAverage() {
      var comments = this.comment;
      var self = this;
      let totalScore = 0;
      let scoreCount = 0;
      if (comments.length > 0) {
        console.log(comments)
        comments.forEach(comment => {
          var score = comment.Score;
          if (score !== null) {
            totalScore += score;
            scoreCount++;
          }
        });
        if (scoreCount > 0) {
          this.averageRating = (totalScore / scoreCount).toFixed(1);
        } else {
          this.averageRating = null;
        }
        var rating = Math.floor(this.averageRating);
        var filledCount = Math.floor(rating);
        self.starTrue = true;
        return Array(filledCount).fill(0);
      } else {
        self.starTrue = false;
        return;
      }

    },
    emptyStarsAverage() {
      var rating = Math.floor(this.averageRating);
      var emptyCount = this.maxStars - Math.floor(rating);
      return Array(emptyCount).fill(0);
    },
    filledStars() {
      return (score) => {
        var filledStars = [];
        var rating = parseFloat(score);
        for (let i = 0; i < rating; i++) {
          filledStars.push(i);
        }
        return filledStars;
      };
    },
    emptyStars() {
      return (score) => {
        var emptyStars = [];
        var rating = parseFloat(score);
        for (let i = 0; i < 5 - rating; i++) {
          emptyStars.push(i);
        }
        return emptyStars;
      };
    },
  },
  methods: {
    dataSort() {
      if (this.productSelect === '價格低到高') {
        this.displayedData.sort((a, b) => a.SalePrice - b.SalePrice);
      } else if (this.productSelect === '書況全新優先') {
        this.displayedData.sort((a, b) => a.BookStatusID - b.BookStatusID);
      } else if (this.productSelect === '上架日期新到舊') {
        this.displayedData.sort((a, b) => new Date(b.Date) - new Date(a.Date));
      }
    },
    loadMore() {
      if (this.allDataLoaded) {
        return;
      }
      var endIndex = this.currentIndex + this.pageSize;
      this.displayedData = this.displayedData.concat(this.reusedData.slice(this.currentIndex, endIndex));
      this.currentIndex = endIndex;
    },
    changeToUserUsed() {
      var getUsedPage = document.querySelector('#nav-reusedbook-tab');
      var tab = new bootstrap.Tab(getUsedPage);
      tab.show();
      document.getElementById('nav-reusedbook-tab').scrollIntoView({ behavior: 'smooth' });
    },
    addToCart(item) {
      if (sessionStorage.getItem('MemberID') == null) {
        Swal.fire({
          title: "請先登入",
          icon: "info",
          showConfirmButton: false,
          timer: 1500,
        })
      } else {
        addCart(item);
      }
    },
    addToLike(item) {
      if (sessionStorage.getItem('MemberID') == null) {
        Swal.fire({
          title: "請先登入",
          icon: "info",
          showConfirmButton: false,
          timer: 1500,
        })
      } else {
        var MemberID = sessionStorage.getItem('MemberID');
        parseInt(MemberID);
        $.ajax({
          method: "POST",
          dataType: "JSON",
          url: `${GetApiUrl()}/Cart/AddFavorite`,
          data: { MemberID: MemberID, ProductID: item.pID },
        })
          .done(function (data) {
            Swal.fire({
              title: data.title,
              icon: "success",
              showConfirmButton: false,
              timer: 1500,
            })
          })
          .fail(function (data) {
            console.log("發生錯誤");
          });
      }
    },
    needBookBtn(ISBN) {
      if (sessionStorage.getItem('MemberID') == null) {
        Swal.fire({
          title: "請先登入",
          icon: "info",
          showConfirmButton: false,
          timer: 1500,
        })
      } else {
        window.location.href = "/member/usedSeek?ISBN="+ISBN;
      }
    },
    saleBookBtn() {
      if (sessionStorage.getItem('MemberID') == null) {
        Swal.fire({
          title: "請先登入",
          icon: "info",
          showConfirmButton: false,
          timer: 1500,
        })
      } else {
        window.location.href = "/member/usedBookStep1";
      }
    }
  },
  async created() {
    var self = this;

    var id = self.$route.params.id;
    var cid = self.$route.params.cid;

    // 取得資料
    try {
      await $.ajax({
        method: "GET",
        dataType: "JSON",
        url: `${GetApiUrl()}/Product/GetCommentInProduct/${id}`,
      })
        .done(function (data) {
          self.comment = data.map((item) => {
            return item;
          });
          self.filledStarsAverage;
        })
    } catch (error) {
      console.log("發生錯誤");
    }

    // 取得資料
    try {
      await $.ajax({
        method: "GET",
        dataType: "JSON",
        url: `${GetApiUrl()}/Product/GetUsedSaleInProduct/${id}`,
      })
        .done(function (data) {
          self.reusedData = data.map((item) => {
            return item;
          });
          self.loadMore();
        })
    } catch (error) {
      console.log("發生錯誤");
    }

    // 取得資料
    try {
      await $.ajax({
        method: "GET",
        dataType: "JSON",
        url: `${GetApiUrl()}/Product/SaleAverageInProduct/${id}`,
      })
        .done(function (data) {
          self.saleAverage = data;
        })
    } catch (error) {
      console.log("發生錯誤");
    }

    try {
      await $.ajax({
        method: "GET",
        dataType: "JSON",
        url: `${GetApiUrl()}/Product/SeekAverageInProduct/${id}`,
      })
        .done(function (data) {
          self.needAverage = data;
        })
    } catch (error) {
      console.log("發生錯誤");
    }
  }
}
</script>

<style scoped src="./css/ProductContent.css"></style>