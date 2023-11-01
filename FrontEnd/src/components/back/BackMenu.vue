<template>
  <div class="nav-wrap">
    <div class="nav-overview-title">
      overview
    </div>
    <div class="nav-box-wrap" v-for="(item, index) in  menuData ">
      <div class="nav-box-title">
        <div class="nav-box-title-icon">
          <i :class="item.icon"></i>
        </div>
        <div class="nav-box-title-text">
          {{ item.title }}
        </div>
        <div class="nav-box-title-arrow">
          <i class="fa-solid fa-angle-right"></i>
        </div>
      </div>
      <div class="nav-box-link-wrap" :style="{ display: chkDisplay(item.data) }">
        <template v-for="( it, k ) in item.data">
          <router-link :to="it.link" class="nav-box-link">{{ it.title }}</router-link>
        </template>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'BackMenu',
  data() {
    return {
      menuData: [
        {
          title: "最新消息",
          icon: "fa-solid fa-newspaper",
          data: [
            { title: "消息列表", link: "/back/lists/News" },
          ],
        },
        {
          title: "書籍管理",
          icon: "fa-solid fa-book",
          data: [
            { title: "書籍分類", link: "/back/lists/ProductCategory" },
            { title: "書籍列表", link: "/back/lists/Product" }
          ],
        },
        {
          title: "會員管理",
          icon: "fa-solid fa-user",
          data: [
            { title: "會員列表", link: "/back/lists/Member" },
          ],
        },
        {
          title: "訂單管理",
          icon: "fa-solid fa-cart-shopping",
          data: [
            { title: "訂單列表", link: "/back/lists/OrderForm" },
          ],
        },
        {
          title: "二手書販售",
          icon: "fa-solid fa-tag",
          data: [
            { title: "二手書列表", link: "/back/lists/UsedSale" },
          ],
        },
      ],
      contentData: [],
    }
  },
  methods: {
    chkActive: function (item) {
      for (let it of item) {
        if (it.link.indexOf(this.$route.params.modelName) != -1) {
          return true;
        }
      }
      return false;
    },
    chkDisplay: function (item) {
      return this.chkActive(item) ? "flex" : "none";
    },
  },
  mounted() {
    var self = this;

    //選單控制
    $(".nav-box-title").on("click", function () {
      let status = $(this).siblings(".nav-box-link-wrap").css("display");
      if (status == "none") {
        $(this).siblings(".nav-box-link-wrap").show(300);
        $(this).find(".nav-box-title-arrow").addClass("arrow-down");
      } else {
        $(this).siblings(".nav-box-link-wrap").hide(300);
        $(this).find(".nav-box-title-arrow").removeClass("arrow-down");
      }
    });
  }
}
</script>

<style scoped>
/* ===== 選單 ===== */

.nav-wrap {
  width: 300px;
  padding: 25px 0;
  background-color: white;
  border-right: 1px #e0e0e0 solid;
}

.nav-overview-title {
  display: flex;
  justify-content: start;
  align-items: center;
  width: 100%;
  padding: 12.5px 25px;
  color: #212121;
  font-weight: bold;
  font-size: 25px;
}

.nav-box-wrap,
.nav-box-link-wrap {
  display: flex;
  justify-content: start;
  align-items: center;
  width: 100%;
  flex-wrap: wrap;
}

.nav-box-title,
.nav-box-link {
  display: flex;
  justify-content: start;
  align-items: center;
  width: 100%;
  padding: 12.5px 25px;
  color: #757575;
  font-weight: bold;
  font-size: 20px;
  flex-grow: 1;
  cursor: pointer;
  transition: all 0.3s ease-in-out;
}

.nav-box-link {
  padding-left: 60px;
}

.nav-box-title:hover,
.nav-box-link:hover {
  color: #212121;
  font-weight: bold;
  background-color: #EFEFEF;
}

.nav-box-title-icon {
  width: 35px;
  padding-right: 15px;
  flex-grow: 0;
}

.nav-box-title-arrow {
  flex-grow: 0;
  transition: all 0.3s ease-in-out;
}

.nav-box-title-arrow.arrow-down {
  transform: rotate(90deg);
}

.nav-box-title-text {
  flex-grow: 1;
}
</style>