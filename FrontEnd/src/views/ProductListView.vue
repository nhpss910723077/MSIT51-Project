<template>
  <TopBanner />
  <section>
    <BreadCrumb :data="breadCrumbData" />
  </section>
  <section id="CategoryData">
    <div class="container">
      <div class="row">
        <PageMenu :data="PageMenuData" />
        <div class="col-md-12 col-lg-9">
          <div class="right-content row justify-content-center">
            <div class="col-lg-12 category-top-title">
              <h1 id="categoryTitle">館藏分類</h1>
            </div>
            <div class="col-lg-3 col-6 category-book-card" v-for="(item, index) in categoryData">
              <div class="card each-book">
                <a :href="item.bookLink">
                  <img class="card-img-top" :src="item.Img1">
                </a>
                <div class="card-body card-content">
                  <div class="card-text-container">
                    <a class="card-title" :href="item.bookLink" :title="item.Name">
                      {{ item.Name }}
                    </a>
                  </div>
                  <div class="product-price">
                    <div>
                      NT${{ item.SalePrice }}
                    </div>
                    <p class="card-text">
                      <i class="fa-solid fa-heart" :class="{ turnRed: item.bookLike }" @click="toggleLike(item)">
                      </i>
                      <i class="fa-solid fa-cart-shopping cartToggle" :class="{ turnRed: item.addCart }"
                        @click="toggleAdd(item)">
                      </i>
                    </p>
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
  name: 'ProductListView',
  data() {
    return {
      breadCrumbData: [
        { title: "首頁", link: "/" },
        { title: "館藏分類", link: "/product/lists/0" },
        { title: "", link: "" },
      ],
      PageMenuData: {
        menuName: "館藏分類",
        menuLink: "/product/lists/0",
        menuData: [],
      },
      productCatrgory: [],
      categoryData: []
    }
  },
  methods: {
    toggleLike(Product) {
      if (sessionStorage.getItem('MemberID') == null) {
        Swal.fire({
          title: "請先登入",
          icon: "info",
          showConfirmButton: false,
          timer: 1500,
        })
        return;
      } else {
        Product.bookLike = !Product.bookLike;
        if (Product.bookLike == true) {
          var MemberID = sessionStorage.getItem('MemberID');
          parseInt(MemberID);
          $.ajax({
            method: "POST",
            dataType: "JSON",
            url: `${GetApiUrl()}/Cart/AddFavorite`,
            data: { MemberID: MemberID, ProductID: Product.pID },
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
        if (Product.bookLike == false) {
          var MemberID = sessionStorage.getItem('MemberID');
          parseInt(MemberID);
          $.ajax({
            method: "POST",
            dataType: "JSON",
            url: `${GetApiUrl()}/Cart/DeleteFavorite`,
            data: { MemberID: MemberID, ProductID: Product.pID },
          })
            .done(function (data) {
              console.log(data);
            })
            .fail(function (data) {
              console.log("發生錯誤");
            });
        }
      }
    },
    toggleAdd(item) {
      if (sessionStorage.getItem('MemberID') == null) {
        Swal.fire({
          title: "請先登入",
          icon: "info",
          showConfirmButton: false,
          timer: 1500,
        })
        return;
      } else {
        item.addCart = !item.addCart;
        if (item.addCart == true) {
          addCart(item);
        } else if (item.addCart == false) {
          deleteCart(item);
        }
      }
    },
    readLike() {
      // 讀取最愛
      var self = this;
      if (sessionStorage.getItem('MemberID') == null) {
        return;
      } else {
        var MemberID = sessionStorage.getItem('MemberID');
        parseInt(MemberID);
        $.ajax({
          method: "GET",
          dataType: "JSON",
          url: `${GetApiUrl()}/Cart/Favorite`,
          data: { MemberID: MemberID },
        })
          .done(function (data) {
            data.forEach((x) => {
              self.categoryData.forEach((y) => {
                if (x.ProductID == y.pID) {
                  y.bookLike = true;
                }
              });
            });
          })
          .fail(function (data) {
            alert("發生錯誤");
          });
      }

    },
    readAdd() {
      var self = this;
      if (sessionStorage.getItem('MemberID') == null) {
        return;
      } else {
        var MemberID = sessionStorage.getItem('MemberID');
        parseInt(MemberID);
        $.ajax({
          method: "GET",
          dataType: "JSON",
          url: `${GetApiUrl()}/Cart/CartNormal`,
          data: { MemberID: MemberID },
        })
          .done(function (data) {
            data.forEach((x) => {
              self.categoryData.forEach((y) => {
                if (x.ProductID == y.pID) {
                  y.addCart = true;
                }
              });
            });
          })
          .fail(function (data) {
            alert("發生錯誤");
          });
      }

    }
  },
  async created() {
    var self = this;

    var id = self.$route.params.id;
    var search = checkGet("search");

    // 取得資料
    try {
      $.ajax({
        method: "GET",
        dataType: "JSON",
        url: `${GetApiUrl()}/Product/GetCategory`,
      })
        .done(function (data) {
          self.productCatrgory = data.map((item, index) => {
            self.PageMenuData.menuData.push({ title: data[index].Name, link: `/product/lists/${index + 1}` });
            return item;
          })
        })

      if (search == null || search == "") {
        if (id < 0) {
          $.ajax({
            method: "GET",
            dataType: "JSON",
            url: `${GetApiUrl()}/Product/GetUserSaleInCategory`,
          })
            .done(function (data) {
              self.categoryData = data.map((item) => {
                item.bookLink = `/product/content/${item.pID}/${item.cID}`;
                document.getElementById("categoryTitle").innerHTML = "目前有二手書的書籍";
                self.breadCrumbData[2].title = "二手書";
                self.readLike();
                self.readAdd();
                return item;
              });
            })
        } else if (id == 0) {
          $.ajax({
            method: "GET",
            dataType: "JSON",
            url: `${GetApiUrl()}/Product/GetDefaultProductInCategory`,
          })
            .done(function (data) {
              self.categoryData = data.map((item) => {
                item.bookLink = `/product/content/${item.pID}/${item.cID}`;
                self.breadCrumbData[1].title = "館藏分類";
                self.breadCrumbData[1].link = "";
                self.breadCrumbData[2].title = null;
                self.breadCrumbData[2].link = null;
                self.readLike();
                self.readAdd();
                return item;
              });
            })
        } else if (id > 0) {
          $.ajax({
            method: "GET",
            dataType: "JSON",
            url: `${GetApiUrl()}/Product/GetProductInCategory/${id}`,
          })
            .done(function (data) {
              self.categoryData = data.map((item) => {
                document.getElementById("categoryTitle").innerHTML = item.CategoryName;
                self.breadCrumbData[2].title = item.CategoryName;
                item.bookLink = `/product/content/${item.pID}/${item.cID}`;
                self.readLike();
                self.readAdd();
                return item;
              });
            })
        }
      } else {
        $.ajax({
          method: "GET",
          dataType: "JSON",
          url: `${GetApiUrl()}/Product/GetSearchInCategory`,
          data: { search: search }
        })
          .done(function (data) {
            if (data == null || data == "") {
              document.getElementById("categoryTitle").innerHTML = `很抱歉沒有關於「${search}」的結果`;
              self.breadCrumbData[2].title = `關鍵字「${search}」`;
            } else {
              self.categoryData = data.map((item) => {
                item.bookLink = `/product/content/${item.pID}/${item.cID}`;
                document.getElementById("categoryTitle").innerHTML = `您搜尋了關鍵字「${search}」`;
                self.breadCrumbData[2].title = `關鍵字「${search}」`;
                self.readLike();
                self.readAdd();
                return item;
              });
            }
          })
        $.ajax({
          method: "POST",
          dataType: "JSON",
          url: `${GetApiUrl()}/Product/PostSearchInCategory`,
          data: { search: search }
        })
          .done(function (data) {
          })
      }
    } catch (error) {
      console.log("發生錯誤");
    }
  },
  components: {
    TopBanner,
    BreadCrumb,
    PageMenu,
  },
}
</script>

<style scoped src="./css/ProductList.css"></style>