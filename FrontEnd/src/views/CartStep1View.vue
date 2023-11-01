<template>
  <TopBanner />
  <section>
    <BreadCrumb :data="breadCrumbData" />
  </section>
  <div class="container myContainner">
    <!-- 沒有商品時 -->
    <div class="noproduct1" v-show="noProduct">
      <p>購物車還沒有商品</p>
    </div>
    <div class="noproduct2" v-show="noProduct">
      <a href="/product/lists"
        ><button class="mybtn mybtnnext">館藏分類</button></a
      >
    </div>
    <div v-show="noProduct != true">
      <!-- 進度條 -->
      <div class="step row">
        <li class="col-12 col-md-4 hov">Step 1 購物車</li>
        <li class="col-12 col-md-4">Step 2 訂單資訊</li>
        <li class="col-12 col-md-4">Step 3 訂單完成</li>
      </div>
      <!-- 商品Title -->
      <div class="row th">
        <div class="col-md-2">商品圖</div>
        <div class="col-md-3">商品名稱</div>
        <div class="col-md">單價</div>
        <div class="col-md">數量</div>
        <div class="col-md">小計</div>
        <div class="col-md">功能</div>
      </div>
      <!-- 商品 -->
      <div class="row td" v-for="(Product, index) in Cart">
        <div class="col-12 col-md-2">
          <img :src="Product.Img1" />
        </div>
        <div class="col-12 col-md-3">{{ Product.Name }}</div>
        <div class="col-12 col-md">NT$ {{ Product.SalePrice }}</div>
        <div class="col-12 col-md">
          <button class="mybtn mybtncoun" @click="sub(Product)">-</button>
          <span class="count">{{ Product.Quantity }}</span>
          <button class="mybtn mybtncoun" @click="plus(Product)">+</button>
        </div>
        <div class="col-12 col-md">
          NT$ {{ Product.SalePrice * Product.Quantity }}
        </div>
        <div class="col-12 col-md justify-content-center function">
          <div class="col-3 col-md-4">
            <button class="mybtn2" @click="mydelete(Product, index)">
              <i class="fa-solid fa-trash"> </i>
            </button>
          </div>
          <div class="col-3 col-md-4">
            <button
              class="mybtn2"
              :class="{ turnRed: Product.Favorite }"
              @click="toggle(Product)"
            >
              <i class="fa-solid fa-heart"></i>
            </button>
          </div>
        </div>
        <hr />
      </div>
      <!-- 小計 -->
      <div class="profooter text-end">小計 :NT$ {{ total() }}</div>
      <div class="profooter text-end">
        <a href="./Step2">
          <button class="mybtn mybtnnext">下一步</button>
        </a>
      </div>
    </div>
  </div>
</template>

<script>
import TopBanner from "@/components/shared/TopBanner.vue";
import BreadCrumb from "@/components/shared/BreadCrumb.vue";

export default {
  name: "CartStep1View",
  data() {
    return {
      breadCrumbData: [
        { title: "首頁", link: "/" },
        { title: "購物車", link: "" },
      ],
      Cart: [
        // {
        //   ID: 1,
        //   Type: "Normal",
        //   ProductID: 1,
        //   Img1: "../images/book1.jpg",
        //   Stock: 99,
        //   Name: "被討厭的勇氣",
        //   SalePrice: 200,
        //   UsedID: null,
        //   Quantity: 4,
        // },
      ],
      noProduct: true,
      MemberID: parseInt(sessionStorage.getItem("MemberID"), 10),
    };
  },
  methods: {
    Update(Product) {
      let updateData = {
        ID: Product.ID,
        Quantity: Product.Quantity,
      };
      // 商品數量更新
      $.ajax({
        method: "POST",
        dataType: "JSON",
        url: `${GetApiUrl()}/Cart/CartUpdate`,
        data: updateData,
      })
        .done(function (data) {
          console.log(data);
        })
        .fail(function (data) {
          console.log("發生錯誤");
        });
    },
    total() {
      var total = 0;
      this.Cart.forEach((Product) => {
        total += Product.SalePrice * Product.Quantity;
      });
      return total;
    },
    plus(Product) {
      if (Product.Stock == Product.Quantity) {
        Swal.fire({
          title: "沒有庫存了!",
          icon: "info",
          showConfirmButton: false,
          timer: 1500,
        });
      }
      if (
        Product.Quantity < 10 &&
        Product.Stock > Product.Quantity &&
        Product.Type == "Normal"
      ) {
        Product.Quantity++;
        this.Update(Product);
      }
    },
    sub(Product) {
      if (Product.Quantity > 1) {
        Product.Quantity--;
        this.Update(Product);
      }
    },
    mydelete(Product, index) {
      var self = this;
      this.Cart.splice(index, 1);
      var deleteData = {
        Type: Product.Type,
        MemberID: this.MemberID,
        ProductID: Product.ProductID,
      };
      $.ajax({
        method: "POST",
        dataType: "JSON",
        url: `${GetApiUrl()}/Cart/CartDelete`,
        data: deleteData,
      })
        .done(function (data) {
          console.log(data);
          readCart();
          if (self.Cart.length == 0) {
            self.noProduct = true;
          }
        })
        .fail(function (data) {
          console.log("發生錯誤");
        });
    },
    toggle(Product) {
      Product.Favorite = !Product.Favorite;
      if (Product.Favorite == true) {
        $.ajax({
          method: "POST",
          dataType: "JSON",
          url: `${GetApiUrl()}/Cart/AddFavorite`,
          data: { MemberID: this.MemberID, ProductID: Product.ProductID },
        })
          .done(function (data) {
            console.log(data);
          })
          .fail(function (data) {
            console.log("發生錯誤");
          });
      }
      if (Product.Favorite == false) {
        $.ajax({
          method: "POST",
          dataType: "JSON",
          url: `${GetApiUrl()}/Cart/DeleteFavorite`,
          data: { MemberID: this.MemberID, ProductID: Product.ProductID },
        })
          .done(function (data) {
            console.log(data);
          })
          .fail(function (data) {
            console.log("發生錯誤");
          });
      }
    },
  },
  async created() {
    var self = this;
    try {
      // 讀取會員購物車_Normal
      await $.ajax({
        method: "GET",
        dataType: "JSON",
        url: `${GetApiUrl()}/Cart/CartNormal`,
        data: { MemberID: this.MemberID },
      })
        .done(function (data) {
          self.Cart = data;
        })
        .fail(function (data) {
          alert("發生錯誤");
        });
      // 讀取會員購物車_Customer
      await $.ajax({
        method: "GET",
        dataType: "JSON",
        url: `${GetApiUrl()}/Cart/CartCustomer`,
        data: { MemberID: this.MemberID },
      })
        .done(function (data) {
          // 將Normal跟Customer合併成一個陣列
          self.Cart = self.Cart.concat(data);
        })
        .fail(function (data) {
          alert("發生錯誤");
        });
      // 資料都讀完後，判斷購物車是否有商品
      if (self.Cart.length != 0) {
        self.noProduct = false;
        // 讀取最愛
        $.ajax({
          method: "GET",
          dataType: "JSON",
          url: `${GetApiUrl()}/Cart/Favorite`,
          data: { MemberID: this.MemberID },
        })
          .done(function (data) {
            data.forEach((x) => {
              self.Cart.forEach((y) => {
                if (x.ProductID == y.ProductID) {
                  y.Favorite = true;
                }
              });
            });
          })
          .fail(function (data) {
            alert("發生錯誤");
          });
      }
    } catch (error) {
      console.log("發生錯誤");
    }
  },
  components: {
    TopBanner,
    BreadCrumb,
  },
};
</script>

<style scoped src="./css/Cart.css"></style>
