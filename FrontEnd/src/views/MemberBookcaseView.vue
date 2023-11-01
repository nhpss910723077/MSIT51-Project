<template>
  <TopBanner />
  <section>
    <BreadCrumb :data="breadCrumbData" />
  </section>

  <section id="app">
    <div class="container">
      <div class="row">
        <PageMenu :data="PageMenuData" />
        <div class="col-ms-12 col-lg-9">
          <!-- <div style="background-color:lightblue; height: 200px;"> -->
          <div>
            <div>
              <div class="memberContent">
                <div class="Content">
                  <div class="title">我的書櫃</div>
                  <div class="bookshelf font-sm">

                    <div class="bookshelf_header">
                      <ul>
                        <li>
                          <button type="button" class="btn font-sm bg1btn" data-bs-toggle="modal"
                            data-bs-target="#bookshelf_insert_search">新增</button>
                        </li>

                      </ul>

                    </div>
                    <hr>
                    <br>

                    <!-- 新增頁面 -->
                    <div class="modal fade" v-show="!show_bookshelf_insert_details" id="bookshelf_insert_search"
                      data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1"
                      aria-labelledby="staticBackdropLabel" aria-hidden="true">
                      <div class="modal-dialog modal-lg modal-dialog-centered">
                        <div class="modal-content">
                          <div class="modal-header">
                            <h5 class="modal-title font-sm" style="padding: 10px;" id="staticBackdropLabel">新增書籍</h5>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                          </div>
                          <div class="modal-body">
                            <div class="bookshelf_insert_ISBN">
                              <label for="bookshelf_insert_ISBN">ISBN：</label><input id="bookshelf_insert_ISBN"
                                type="text" placeholder="請輸入書籍的ISBN碼">
                              <button type="button" class="btn font-sm bg1btn" @click="ISBNSearch">查詢</button>
                              <!-- data-bs-target="#bookshelf_insert_details" -->
                            </div>
                          </div>

                        </div>
                      </div>
                    </div>
                    <!-- 新增2 -->
                    <div class="modal fade" v-show="show_bookshelf_insert_details" id="bookshelf_insert_details"
                      data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1"
                      aria-labelledby="staticBackdropLabel" aria-hidden="true">
                      <div class="modal-dialog modal-lg modal-dialog-centered">
                        <div class="modal-content">
                          <div class="modal-header">
                            <h5 class="modal-title font-sm font-bold" style="padding: 10px;" id="staticBackdropLabel">
                              新增書籍：{{ ISBNResult.Name }}</h5>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                          </div>
                          <div class="modal-body bookshelf_insert_details_body">
                            <div class="imgDiv">
                              <img :src="ISBNResult.Img1" :alt="ISBNResult.Name">
                            </div>
                            <div>
                              <table>

                                <tr>
                                  <th>作者</th>
                                  <!-- 作者分行出現 -->
                                  <!-- <td>
                                    <div v-for="Author in AuthorList(item.Author)">
                                      <span class="txtshort" :title="Author">
                                        {{ Author }}
                                      </span>
                                    </div>
                                  </td> -->
                                  <!-- 作者逗號分隔 -->
                                  <td>
                                    <div>
                                      <span class="txtshort" :title="ISBNResult.Author">
                                        {{ ISBNResult.Author }}
                                      </span>
                                    </div>
                                  </td>
                                </tr>
                                <tr>
                                  <th>出版社</th>
                                  <td class="txtshort" :title="ISBNResult.Publisher">
                                    {{ ISBNResult.Publisher }}
                                  </td>
                                </tr>
                                <tr>
                                  <th>ISBN10</th>
                                  <td>{{ ISBNResult.ISBN10 }}
                                  </td>
                                </tr>
                                <tr>
                                  <th>ISBN13</th>
                                  <td>{{ ISBNResult.ISBN13 }}
                                  </td>
                                </tr>
                                <tr>
                                  <th>分類</th>
                                  <td>{{ ISBNResult.ProductCategory }}</td>
                                </tr>
                                <tr>
                                  <th>評分</th>
                                  <td>
                                    <!-- v-model="ISBNResult.Score" @mouseleave="resetStars(Bookcase.Score)"-->
                                    <div>
                                      <p class="rating" @click="submitRating">
                                        <i v-for="star in 5" :key="star" class="fa-regular fa-star"
                                          @mouseover="hoverStar(star)"
                                          :class="{ 'fa-solid': star <= currentRating, 'fa-regular': star > currentRating }"></i>
                                      </p>
                                    </div>
                                  </td>
                                </tr>

                                <tr>
                                  <th>評論</th>
                                  <td>
                                    <button class="btn bg2btn" type="button" data-bs-toggle="collapse"
                                      data-bs-target="#bookReview" aria-expanded="false" aria-controls="collapseExample">
                                      撰寫書評
                                    </button>
                                  </td>
                                </tr>

                              </table>

                            </div>


                            <div class="collapse bookReview" id="bookReview">
                              <div class="card card-body font-sm">
                                <hr>
                                <label class="font-bold">
                                  書評標題 ：</label>
                                <p></p>
                                <input type="text" class="bookReviewTitle">
                                <p></p>
                                <label class="font-bold">
                                  書評內容 ：</label>
                                <p></p>
                                <textarea name="bookReview" class="bookReviewText"></textarea>
                                <p></p>

                              </div>
                            </div>

                          </div>
                          <div class="modal-footer ">
                            <button type="submit" class="btn bg1btn" @click="BookInsert(this)">新增</button>
                            <button type="button" class="btn bg2btn" data-bs-dismiss="modal">取消</button>
                          </div>
                        </div>

                      </div>
                    </div>
                  </div>
                  <!-- 新增頁面end -->

                  <div class="bookCardList font-sm">
                    <div class="bookCardLoop" v-for="item, index in bookcase" :key="item.ProductID">
                      <div class="bookCard" data-bs-toggle="modal" :data-bs-target="'#modal-' + item.ProductID">
                        <img v-bind:src="item.Img1" :alt="item.Name">
                        <div class="txtshort" :title="item.Name">{{ item.Name }}</div>
                        <div class="rating">
                          <!-- 固定綁定 item.score -->
                          <i v-for="star in 5" :key="star" class="fa-regular fa-star"
                            :class="{ 'fa-solid': star <= item.Score, 'fa-regular': star > item.Score }"></i>
                        </div>
                      </div>
                      <!-- 書點開詳細 -->
                      <!-- 如果有點"編輯評論"或"星星"就要把:(或是星星改成隨動隨存?)
                                                    1. data-bs-backdrop="true" 改成static(先PASS)
                                                    2. textarea和input可以輸入
                                                    3. 出現儲存或取消
                                                    4. .bookReviewText:focus =>  /* border: 1px solid var(--bg-color1); */-->
                      <div class="modal fade" :id="'modal-' + item.ProductID" data-bs-backdrop="true"
                        data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                        <div class="modal-dialog modal-lg modal-dialog-centered">
                          <div class="modal-content">
                            <div class="modal-header">
                              <h5 class="modal-title font-sm font-bold" style="padding: 10px;" id="staticBackdropLabel">
                                {{ item.Name }}</h5>
                              <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body bookshelf_insert_details_body">
                              <div class="imgDiv">
                                <img :src="item.Img1" :alt="item.Name">
                              </div>
                              <div>
                                <table>
                                  <tr>
                                    <th>作者</th>
                                    <!-- 作者分行出現 -->
                                    <!-- <td>
                                                                            <div v-for="Author in AuthorList(item.Author)">
                                                                                <span class="txtshort" :title="Author">
                                                                                    {{Author}}
                                                                                </span>
                                                                            </div>
                                                                        </td> -->
                                    <!-- 作者逗號分隔 -->
                                    <td>
                                      <div>
                                        <span class="txtshort" :title="item.Author">
                                          {{ item.Author }}
                                        </span>
                                      </div>
                                    </td>
                                  </tr>
                                  <tr>
                                    <th>出版社</th>
                                    <td class="txtshort" :title="item.Publisher">
                                      {{ item.Publisher }}</td>
                                  </tr>
                                  <tr>
                                    <th>ISBN10</th>
                                    <td>{{ item.ISBN10 }}</td>
                                  </tr>
                                  <tr>
                                    <th>ISBN13</th>
                                    <td>{{ item.ISBN13 }}</td>
                                  </tr>
                                  <tr>
                                    <th>分類</th>
                                    <td>{{ item.ProductCategory }}</td>
                                  </tr>
                                  <tr>
                                    <th>評分</th>
                                    <td>
                                      <div>
                                        <p class="rating" @click="submitRating(item)">
                                          <i v-for="star in 5" :key="star" @mouseover="hoverStar(star)"
                                            class="fa-regular fa-star"
                                            :class="{ 'fa-solid': star <= item.Score, 'fa-regular': star > item.Score }"></i>
                                        </p>
                                      </div>
                                    </td>
                                  </tr>

                                  <tr>
                                    <th>評論</th>
                                    <td>
                                      <button class="btn bg2btn" type="button" @click="bookReviewEdit(item)">
                                        編輯書評
                                      </button>
                                    </td>
                                  </tr>

                                </table>
                              </div>
                              <div class="bookReview">
                                <div class="card card-body font-sm">
                                  <hr>
                                  <label class="font-bold">書評標題 (非必填)：</label>
                                  <p></p>
                                  <input type="text" class="bookReviewTitle" :class="`A${item.ProductID}`" readOnly="true"
                                    v-model="item.ReviewTitle">
                                  <p></p>
                                  <label class="font-bold">書評內容 (必填)：</label>
                                  <p></p>
                                  <textarea name="bookReview" class="bookReviewText" :class="`B${item.ProductID}`"
                                    readOnly="true" required v-model="item.Review"></textarea>

                                </div>
                              </div>
                            </div>
                            <div class="modal-footer edit" :class="`edit${item.ProductID}`">
                              <!-- 送資料到資料庫-EDIT -->
                              <button type="button" class="btn bg1btn" @click="BookEdit(item)">儲存</button>
                              <button type="button" class="btn bg2btn" data-bs-dismiss="modal">取消</button>
                            </div>
                          </div>

                        </div>

                      </div>
                    </div>

                    <!-- 書點開詳細:end -->
                  </div>
                </div>

              </div>

            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
import TopBanner from '@/components/shared/TopBanner.vue'
import BreadCrumb from '@/components/shared/BreadCrumb.vue'
import PageMenu from '@/components/shared/PageMenu.vue'

export default {
  name: 'MemberBookcaseView',
  data() {

    return {
      MemberID: parseInt(sessionStorage.getItem('MemberID')),
      breadCrumbData: [
        { title: "首頁", link: "/" },
        { title: "會員中心", link: "/member/index" },
        { title: "我的書櫃", link: "" },
      ],
      PageMenuData: {
        menuName: "會員中心",
        menuLink: "/member/index",
        menuData: []
      },
      // MenuList: [],
      bookcase: [],
      ISBNResult: {},
      ISBNInsert: {},
      show_bookshelf_insert_details: false,
      star1Hover: false,
      star2Hover: false,
      star3Hover: false,
      star4Hover: false,
      star5Hover: false,
      currentRating: null,

    }
  },
  methods: {

    addClass:
      function (href) {
        var self = this;
        var f = href.split("/");
        if (window.location.href.indexOf(f[f.length - 1]) > 0) {
          return true;
        } else {
          return false;
        }
        // return false;
      },
    bookReviewEdit(item) {
      console.log(item.ISBN10);
      console.log(item.ISBN13);
      document.querySelector(`.A${item.ProductID}`).readOnly = false;
      document.querySelector(`.B${item.ProductID}`).readOnly = false;
      document.querySelector(`.B${item.ProductID}`).focus();

      document.querySelector(`.edit${item.ProductID}`).style.display = "block";
    },
    ISBNSearch: function () {
      var self = this;

      var ISBNInput = document.querySelector("#bookshelf_insert_ISBN").value;
      console.log(ISBNInput);
      console.log(typeof (ISBNInput));
      if (ISBNInput == "") {
        Swal.fire({

          title: "請輸入書籍的ISBN碼",
          icon: "info",
          timer: 2000,
          showConfirmButton: false,

        });
      } else if (ISBNInput.length != 10 && ISBNInput.length != 13) {
        Swal.fire({

          title: "請輸入10或13字的ISBN碼",
          icon: "info",
          timer: 2000,
          showConfirmButton: false,

        });
      } else {
        $.ajax({
          method: "POST",
          dataType: 'JSON',
          url: `${GetApiUrl()}/member/ISBNSearch/${self.MemberID}`,
          data: { ISBNInput: ISBNInput },
        }).done(function (data) {
          console.log(data);
          if (data.ISBN10 == null && data.ISBN13 == null && data.result != null) {
            Swal.fire({

              title: data.title,
              icon: data.result,
              timer: 2000,
              showConfirmButton: false,

            });
            setTimeout(
              function () {
                $("#bookshelf_insert_search").modal("show");
              }, 2000
            )
            return
          } else {
            self.ISBNResult = data;
            console.log(self.ISBNResult);
            if (self.ISBNResult != null) {

              // self.show_bookshelf_insert_details = true;
              // console.log(self.show_bookshelf_insert_details);
              setTimeout(() => {
                $("#bookshelf_insert_details").modal("show");
              }, 500);

            } else {
              Swal.fire({

                title: "查無此項目",
                icon: "info",
                timer: 2000,
                showConfirmButton: false,

              });
              setTimeout(
                function () {
                  $("#bookshelf_insert_search").modal("show");
                }, 2000
              )
            }
          }
        }).fail(function () {
          Swal.fire({

            title: "查無此項目",
            icon: info,
            timer: 2000,
            showConfirmButton: false,

          });
          setTimeout(
            function () {
              $("#bookshelf_insert_search").modal("show");
            }, 2000
          )
        });
      }
    },
    // AuthorList(Authors) {
    //   return Authors.split("、");
    // },

    BookInsert() {
      var self = this;
      console.log(self.MemberID)
      self.ISBNInsert = {
        // 
        MemberID: self.MemberID,
        // int 
        ProductID: self.ISBNResult.ID,
        // public string? 
        ReviewTitle: document.querySelector(".bookReviewTitle").value,
        // public string?
        Review: document.querySelector(".bookReviewText").value,
        // int?
        Score: self.currentRating,
      },
        $.ajax({
          method: "POST",
          dataType: "JSON",
          url: `${GetApiUrl()}/member/BookInsert/${self.MemberID}`,
          data: self.ISBNInsert
        }).done(function (insertResult) {
          console.log(insertResult)
          Swal.fire({

            title: insertResult.title,
            icon: insertResult.result,
            timer: 2000,
            showConfirmButton: false,

          }).then(function () {
            window.location.href = window.location.href
          })

        });
    },
    BookEdit(item) {
      $.ajax({
        method: "POST",
        dataType: "JSON",
        url: `${GetApiUrl()}/member/BookEdit`,
        data: item,
      }).done(function (editResult) {
        console.log(editResult)
        Swal.fire({
          title: editResult.title,
          icon: editResult.result,
          timer: 2000,
          showConfirmButton: false,
        }).then(function () {
          window.location.href = window.location.href
        }
        )
      });
    },
    hoverStar(star) {
      var self = this;
      for (let i = 1; i <= 5; i++) {
        self['star' + i + 'Hover'] = star >= i;
      }
      self.currentRating = star;
      console.log('評分: ' + self.currentRating);
    },
    submitRating(item) {
      var self = this;
      self.bookcase.Score = item;
      self.ISBNInsert.Score = item;
      if (self.currentRating == 0) {
        item.Score = null
      } else {
        item.Score = self.currentRating;
      }
      console.log(item.Score)
      console.log('評分: ' + self.currentRating);
      if (document.querySelector(`.edit${item.ProductID}`) != null) {
        document.querySelector(`.edit${item.ProductID}`).style.display = "block";
      }
    }


  },
  async created() {
    var self = this;
    // 取得資料
    try {
      $.ajax({
        method: "GET",
        dataType: 'JSON',
        url: `${GetApiUrl()}/member/Bookcase/${self.MemberID}`,
      }).done(function (data) {
        self.bookcase = data;
        console.log(self.bookcase);

      });
    } catch (error) {
      console.log("發生錯誤");
    }

    // 取得資料
    try {
      $.ajax({
        method: "GET",
        dataType: 'JSON',
        url: `${GetApiUrl()}/member/MemberMenu`,
      }).done(function (data) {
        self.PageMenuData.menuData = data;
        console.log(self.PageMenuData.menuData);

      });
    } catch (error) {
      console.log("發生錯誤");
    }
  },
  components: {
    TopBanner,
    BreadCrumb,
    PageMenu,
  }
}
</script>

<style scoped src="./css/Member.css"></style>