<template>
  <TopBanner />
  <section>
    <BreadCrumb :data="breadCrumbData" />
  </section>
  <section>
    <div class="container">
      <div class="row">
        <PageMenu :data="PageMenuData" />
        <div class="col-9">
          <div class="row" id="annList">
            <div class="col-6 col-md-4 col-xl-3 mycard" v-for="item in anns">

              <a :href="'/news/content/' + item.newsID">
                <div class="card ccc" >
                  <img :src="item.pic" class="card-img-top">

                  <template v-if="item.text">
                    <div class="card-body">
                      <h2 class="card-title mycardTitle">{{ item.title }}</h2>
                      <div class="card-text">公告日期:</div>
                      <div class="card-text">{{ item.text }} </div>
                    </div>
                  </template>

                  <template v-else>
                    <div class="card-body">
                      <h2 class="card-title mycardTitle">{{ item.title }}</h2>
                      <div class="card-text">優惠活動:</div>
                      <div>{{ item.start }}</div>
                      <div>至</div>
                      <div>{{ item.end }}</div>
                    </div>
                  </template>
                </div>
              </a>
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
  name: 'NewsListView',
  data: function () {
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
      anns: [],

    }
  },

  async created() {
    var self = this;

    var id = self.$route.params.id;
    // 取得資料
    try {
      if (id == 1) {
        await $.get(`${GetApiUrl()}/news/EventData`, (rr) => {
          console.log(rr);
          this.anns = rr;
        });
      }
      else {
        await $.get(`${GetApiUrl()}/news/AnnData`, (rr) => {
          console.log(rr);
          this.anns = rr
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
  }
}
</script>

<style scoped src="./css/Login&news.css"></style>