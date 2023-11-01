<template>
  <TopBanner />
  <section>
    <BreadCrumb :data="breadCrumbData" />
  </section>
  <div class="container myContainner">
    <!-- 進度條 -->
    <div class="step row">
      <li class="col-12 col-md-4">Step 1 購物車</li>
      <li class="col-12 col-md-4">Step 2 訂單資訊</li>
      <li class="col-12 col-md-4 hov">Step 3 訂單完成</li>
    </div>
    <!-- 內容 -->
    <div class="finish">
      <img :src="`/images/shoppingCart_test/OK.png`" alt="" />
      <p>感謝您的購買!</p>
      <div class="row justify-content-center">
        <div class="col-6 col-md-3">
          <a href="/"><button class="mybtn mybtnnext">返回首頁</button></a>
        </div>
        <div class="col-6 col-md-3">
          <a href="/member/order"
            ><button class="mybtn mybtnnext">查詢訂單</button></a
          >
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import TopBanner from "@/components/shared/TopBanner.vue";
import BreadCrumb from "@/components/shared/BreadCrumb.vue";

export default {
  name: "CartStep3View",
  data() {
    return {
      breadCrumbData: [
        { title: "首頁", link: "/" },
        { title: "購物車", link: "" },
      ],
    };
  },
  components: {
    TopBanner,
    BreadCrumb,
  },
};
</script>

<style scoped src="./css/Cart.css"></style>
