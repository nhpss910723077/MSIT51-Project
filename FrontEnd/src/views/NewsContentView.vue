<template>
  <TopBanner />
  <section>
    <BreadCrumb :data="breadCrumbData" />
  </section>
  <section>
    <div class="container">
      <div class="row">
        <PageMenu :data="PageMenuData" />
        <div class="col-8 col-sm-9 myarticle">

          <template v-if="events.text">
            <img src="/images/公告內頁.png">
            <h2> {{ events.title }}</h2>
            <p>公告日期:{{ events.text }}</p>
          </template>

          <template v-else>
            <img :src="events.pic">
            <h2> {{ events.title }}</h2>
            <p>活動日期:{{ events.start }}至{{ events.end }}</p>
          </template>

          <p v-html="events.content"></p>


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
  name: 'NewsContentView',
  data() {
    return {
      breadCrumbData: [
        { title: "首頁", link: "/" },
        { title: "最新消息", link: "/news/lists/1" },
        { title: "最新公告", link: "" },
      ],
      PageMenuData: {
        menuName: "最新消息",
        menuLink: "/news/lists",
        menuData: [
          { title: "優惠活動", link: "/news/lists/1" },
          { title: "最新公告", link: "/news/lists/2" },
        ]
      },
      events: {},
    }
  },
  async created() {
    var self = this;
    var id = self.$route.params.id;

    // 取得資料
    try {
      $.get(`${GetApiUrl()}/news/NewsContent?newsID=${id}`, (rr) => {
        console.log(rr);
        self.events = rr
      })



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

<style scoped src="./css/Login&news.css"></style>