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
                  <div class="title">二手書販售</div>
                  <div class="secondHandBook">
                    <div class="flexContainer">

                      <div class="saleApplyButton">
                        <router-link :to="'/member/usedBookStep1'" class="box"><button class="btn bg2btn">我要賣書</button></router-link>
                        <!-- <a href="/member/usedBookStep1"><button class="btn bg2btn">我要賣書</button></a> -->
                      </div>
                      <div class="Listfilter">
                        <div>
                          <input checked id="review" type="radio" name="secondHandBook-Listfilter" value="0"
                            v-model="selectedVerifyStatus">
                          <label for="review" class=" font-sm">審核中</label>

                          <input id="sale" type="radio" name="secondHandBook-Listfilter" value="1"
                            v-model="selectedVerifyStatus">
                          <label for="sale" class=" font-sm">已上架</label>

                          <input id="sold" type="radio" name="secondHandBook-Listfilter" value="2"
                            v-model="selectedVerifyStatus">
                          <label for="sold" class=" font-sm">已賣出</label>

                          <input id="Unlist" type="radio" name="secondHandBook-Listfilter" value="3"
                            v-model="selectedVerifyStatus">
                          <label for="Unlist" class=" font-sm">已下架</label>

                        </div>
                      </div>
                    </div>
                    <hr style="border: 0;margin: 3px;">
                    <div class="flexContainer">
                      <table class="font-sm myListTable flexContainer"
                        :class="{ 'myListTable5': selectedVerifyStatus == '0' || selectedVerifyStatus == '1', 'myListTable4': selectedVerifyStatus != '0' && selectedVerifyStatus != '1' }">

                        <tr class="flexContainer firstTr">
                          <th>ISBN</th>
                          <th>書名</th>
                          <th>售價</th>
                          <th>書況評估</th>
                          <th v-if="selectedVerifyStatus == 0 || selectedVerifyStatus == 1">修改</th>
                        </tr>

                        <tr class="flexContainer" v-for="item in usedBookList"
                          v-show="item.VerifyStatus == selectedVerifyStatus">
                          <td>{{ item.ISBN10 }}</td>
                          <td>
                            <div class="txtshort" :title="item.ProductName">
                              {{ item.ProductName }}</div>
                          </td>

                          <td>{{ item.SalePrice }}</td>
                          <td>
                            <select disabled name="condition" id="condition" style="text-align: center;"
                              v-model="item.BookStatus">
                              <option disabled>請選擇分級</option>
                              <option value="0" selected>全新</option>
                              <option value="1">良好</option>
                              <option value="2">有註記</option>
                            </select>
                          </td>
                          <td v-if="item.VerifyStatus == 0 || item.VerifyStatus == 1">
                            <button class="btn font-sm bg2btn" @click="Unlist(item)">申請下架</button>
                          </td>
                        </tr>



                      </table>


                    </div>


                  </div>

                </div> <br>

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
        { title: "二手書販售", link: "" },
      ],
      PageMenuData: {
        menuName: "會員中心",
        menuLink: "/member/index",
        menuData: []
      },
      usedBookList: [],
      selectedVerifyStatus: "1",
      // MenuList: []
    }


    // test
  },
  methods: {

    addClass:
      function (href) {
        var f = href.split("./");
        console.log(window.location.href);
        console.log(f[f.length - 1]);
        console.log(window.location.href.indexOf(f[f.length - 1]));

        if (window.location.href.indexOf(f[f.length - 1]) > 0) {
          return true;
        } else {
          return false;
        }
        // return false;
      },
    Unlist(item) {
      var self = this;
      Swal.fire({
        html:
          `<p></p>` +
          `<img src="${item.Img1}" alt="${item.ProductName}" style="height = 100px">` +
          `<p></p>` +
          `<div style="font-size = 20px;">
            書名：${item.ProductName}</div>` +
          `<p></p>` +
          `<div style="font-size = 25px">確定要下架此書籍嗎?</div>`,

        // title: "確定要下架此書籍嗎?",
        // icon: "info",
        showConfirmButton: true,
        showCancelButton: true,
      }).then(function (result) {
        if (result.isConfirmed) {
          $.ajax({
            method: "POST",
            dataType: 'JSON',
            url: `${GetApiUrl()}/member/UsedBookUnlist`,
            data: item,
            mode: "cors",
          }).done(function (data) {
            Swal.fire({
              title: data.title,
              icon: data.result,
              timer: 2000,
              showConfirmButton: false,
            }).then(function () {
              self.selectedVerifyStatus = "3";
              window.location.href = window.location.href
            });

          });
        }

       })

    }
  },
  async created() {
    var self = this;

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

    try {
      $.ajax({
        method: "GET",
        dataType: 'JSON',
        url: `${GetApiUrl()}/member/UsedBookList/${self.MemberID}`,
        // mode: 'cors', 
      }).done(function (data) {
        console.log(data);
        self.usedBookList = data;
        console.log(self.usedBookList);

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