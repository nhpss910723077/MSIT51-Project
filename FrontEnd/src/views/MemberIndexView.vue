<template>
  <TopBanner />
  <section>
    <BreadCrumb :data="breadCrumbData" />
  </section>

  <section>
    <div class="container">
      <div class="row">
        <PageMenu :data="PageMenuData" />
        <div class="col-ms-12 col-lg-9 areaRight">
          <!-- <div style="background-color:lightblue; height: 200px;"> -->

          <div>
            <div class="memberContent">
              <div class="Content">

                <div class="title">
                  Let's Read,{{ IndexData.Name }}
                  <template v-if="IndexData.LineMemberNumber==null || IndexData.LineMemberNumber==''">
                    <a class="qrcode-container" href="#">
                      <span>你還沒綁定LINE！現在綁定就送購物金200點！→</span>
                      <img src="/images/QRcode.png">
                    </a>
                    <hr>
                  </template>
                  <template v-if="IndexData.LineMemberNumber!=null && IndexData.LineMemberNumber!=''">
                    
                      <span class="font-sm lineBind">Line已成功綁定</span>
                   
                    <hr>
                  </template>
                </div>

                <div class="font-m flexContainer">
                  <div class="ShoppingMoneyRecord font-m">
                    <a href="">
                      <div class="flexContainer">
                        <span class="IndexName"><i class="fa-solid fa-sack-dollar"></i>
                          &nbsp;&nbsp;&nbsp;購物金&nbsp;$&nbsp;{{ IndexData.ShoppingMoneyRecord }}</span>
                        <span class="IndexArrow">></span>
                      </div>
                    </a>
                    <hr>
                  </div>
                  <div class="FavoriteCount font-m">
                    <a href="/member/Favorite">
                      <div class="flexContainer">
                        <span class="IndexName"><i class="fa-solid fa-heart"></i>
                          &nbsp;&nbsp;&nbsp;收藏清單&nbsp; {{ IndexData.FavoriteCount }}&nbsp;項</span>
                        <span class="IndexArrow">></span>
                      </div>
                    </a>
                    <hr>
                  </div>
                  <!-- <div class="couponCount font-m">
                    <a href="./member_coupon.html">
                      <div class="flexContainer">
                        <span class="IndexName"><i class="fa-solid fa-ticket"></i>
                          &nbsp;優惠券 3 張</span>
                        <span class="IndexArrow">></span>
                      </div>
                    </a>
                    <hr>
                  </div> -->


                </div>
                <!-- border: 1px var(--bg-color1) solid;border-radius: 15px; -->

                <div class="orderCount font-m">
                  <a href="/member/order">
                    <div class="flexContainer">
                      <span style="flex:11;"><i class="fa-solid fa-clipboard-list"></i>&nbsp;&nbsp;&nbsp;&nbsp;訂單查詢</span>
                      <span style="flex:1;text-align: center;">></span>
                    </div>
                  </a>
                  <hr>
                  <div class="col-lg-8 font-sm">
                    <div class="orderCountList" v-for="item in IndexData.orderCount">
                      &nbsp;{{ item.DataCategory }} {{ item.StatusCount }} 筆
                    </div>
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
  name: 'MemberIndexView',
  data() {
    return {
      MemberID: parseInt(sessionStorage.getItem('MemberID')),
      breadCrumbData: [
        { title: "首頁", link: "/" },
        { title: "會員中心", link: "/member/index" },
        { title: "我的帳戶", link: "" },
      ],
      PageMenuData: {
        menuName: "會員中心",
        menuLink: "/member/index",
        menuData: []
      },

      IndexData: {
        lineBind: true,
      },
      MenuList: [],
    }
  },
  methods: {

  },
  async created() {
    var self = this;
    // 取得資料
    try {
      await $.ajax({
        method: "GET",
        dataType: 'JSON',
        url: `${GetApiUrl()}/member/IndexData/${self.MemberID}`,
      }).done(function (data) {
        self.IndexData = data;
        console.log(self.IndexData);
        console.log(self.IndexData.orderCount);
        // self.IndexData.LineMemberNumber =123;
      });
    } catch (error) {
      console.log("發生錯誤");
    }

    // 取得資料
    try {
      await $.ajax({
        method: "GET",
        dataType: 'JSON',
        url: `${GetApiUrl()}/member/MemberMenu`,
      }).done(function (data) {
        self.PageMenuData.menuData = data;
        console.log(self.PageMenuData);

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