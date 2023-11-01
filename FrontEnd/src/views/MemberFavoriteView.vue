<template>
  <TopBanner />
  <section>
    <BreadCrumb :data="breadCrumbData" />
  </section>

  <section>
    <div class="container">
      <div class="row">
        <PageMenu :data="PageMenuData" />
        <div class="col-ms-12 col-lg-9">
          <!-- <div style="background-color:lightblue; height: 200px;"> -->
          <div class="memberContent">
            <div class="Content">
              <div class="title">收藏清單</div>
              <div class=" flexContainer">
                <table class="flexContainer favoritesList" v-show="FavoriteList.length > 0">
                  <tr class="flexContainer">
                    <th>商品名稱</th>
                    <th colspan="2"></th>
                    <th>商品金額</th>
                    <th colspan="2"></th>
                  </tr>
                  <tr class="flexContainer" v-for="item in FavoriteList">
                    <td><img :src="item.Img1" ></td>
                    <td colspan="2" class="txtshort" :title="item.Name">{{ item.Name }}</td>
                    <td>${{ item.SalePrice }}</td>
                    <td colspan="2">
                      <button class="btn bg1btn" @click="addToCart(item)">加入購物車</button>
                      &nbsp;
                      <i class="fa-solid fa-trash FavoriteDelete" @click="FavoriteDelete(item)"></i>
                    </td>
                  </tr>
                  


                </table>

                <div class="NoFavorite font-bold font-m" v-show="!FavoriteList.length">
                  <div>"目前尚無收藏項目"</div>
                  <div><a href="/"><button class="btn bg2btn">選書去</button></a></div>
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
  name: 'MemberFavoriteView',
  data() {
    return {
      MemberID: parseInt(sessionStorage.getItem('MemberID')),
      breadCrumbData: [
        { title: "首頁", link: "/" },
        { title: "會員中心", link: "/member/index" },
        { title: "收藏清單", link: "" },
      ],
      PageMenuData: {
        menuName: "會員中心",
        menuLink: "/member/index",
        menuData: []
      },
      // MenuList: [],
      FavoriteList: [],
    }
  },
  methods: {
    FavoriteDelete(item) {
      console.log(item.ID);
      $.ajax({
        method: "POST",
        dataType: 'JSON',
        url: `${GetApiUrl()}/member/FavoriteDelete/${item.ID}`,
      }).done(function (FavoriteDeleteResult) {
        Swal.fire({
          title: FavoriteDeleteResult.title,
          icon: FavoriteDeleteResult.result,
          timer: 2000,
          showConfirmButton: false,
        }).then(function(){
          window.location.href = window.location.href
        });
        
      });
    },
    addToCart(item){
      addCart(item);
    }
  },
  async created() {
    var self = this;

    

    // 取得資料
    try {
      $.ajax({
        method: "GET",
        dataType: 'JSON',
        url: `${GetApiUrl()}/member/FavoriteList/${self.MemberID}`,
      }).done(function (data) {
        self.FavoriteList = data;
        // console.log(self.FavoriteList);

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
        // console.log(self.PageMenuData.menuData);

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