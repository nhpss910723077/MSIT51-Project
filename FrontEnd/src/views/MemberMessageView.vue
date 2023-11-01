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
          <div>
            <div>
              <div class="memberContent">
                <div class="Content">
                  <div class="title">
                    <div>訊息通知</div>
                  </div>
                  <div class="couponList font-sm">
                    <div class="couponHeader">
                      <div class="couponHeaderTitle">訊息列表</div>
                      
                    </div>
                    <hr class="titleHr">
                    <table class="messageList">
                      <tr v-for="item in MessageList">
                        <td>{{ item.Content }}</td>
                        <td>{{ item.UpdateTime.split("T")[0] }}</td>
                        <td class="moreMessage"><button class="btn bg2btn">看更多...</button>
                        </td>

                      </tr>


                    </table>
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
  name: 'MemberMessageView',
  data() {
    return {
      MemberID: parseInt(sessionStorage.getItem('MemberID')),
      breadCrumbData: [
        { title: "首頁", link: "/" },
        { title: "會員中心", link: "/member/index" },
        { title: "訊息通知", link: "" },
      ],
      PageMenuData: {
        menuName: "會員中心",
        menuLink: "/member/index",
        menuData: []
      },
      MessageList:[],
      // MenuList: [],
    }
  },
  methods: {

  },
  async created() {
    var self = this;

    try {
      $.ajax({
        method: "GET",
        dataType: 'JSON',
        url: `${GetApiUrl()}/member/MessageList${self.MemberID}`,
      }).done(function (data) {
        self.MessageList = data;
        console.log(self.MessageList);

      });
    } catch (error) {
      console.log("發生錯誤");
    };
    
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