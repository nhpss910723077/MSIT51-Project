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
                  <div class="title">二手販賣須知</div>
                  <div class="secondHandBook flexContainer">
                    <div class="flexContainer">
                      <div class="font-m steps">如何賣書</div>
                      <div class="flexContainer steps">
                        1. 上架申請：輸入ISBN並自訂售價及書籍狀況<br>
                        2. 收款方式：選擇將銷售所得匯入購書金或自訂的銀行帳戶<br>
                        3. 裝箱交寄：多元管道寄書<br>
                        4. 開始販售：驗收無誤為您上架販售 (銷售所得匯入TAAZE帳戶)
                      </div>
                      <div class="font-m">上架書籍規定</div>
                      <div class="flexContainer steps">
                        <p></p>
                        注意！以下為ReadUse不賣的二手書，寄書前要特別注意唷：<br>

                        1. 中文雜誌、歐美雜誌，非書籍類商品，如卡牌，影音光碟等。<br>
                        2. 無定價、無出版日期、無ISBN、無版權頁之二手書。<br>
                        3. 來自租書店及漂書單位或蓋租書店章、政府機關學校館藏章、結緣章、非賣品/不得轉贈(售)章之二手書。<br>
                        4. 高中/國中/國小教科書、參考書、兒童教具類二手書。<br>
                        5. 書況不佳之二手書：缺書封、缺書衣、缺內頁、裝訂脫落、印刷及裁切瑕疵、有書釘、汙痕、損傷、塗鴉、膠貼、蟲穢/蛀、沾黏、異味。<br>
                        6. 不分售之套書，有缺書而不成套之二手書。<br>
                        7. 已使用過之各類練習簿、測驗簿、著色本或含習題之二手書，以及缺少附件即影響使用之二手書。<br>
                        8. 註記證件字號等個人資料之二手書。<br>
                        ReadUse保留其他特定二手書不代售之權利。賣家寄送至ReadUse的二手書，如有上述情形者，ReadUse將執行本服務條款【第十二條 二手書寄送至ReadUse後，無法代售情形之後續處理】。

                      </div>
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
  name: 'MemberPolicyView',
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
  },
  components: {
    TopBanner,
    BreadCrumb,
    PageMenu,
  }
}
</script>

<style scoped src="./css/Member.css"></style>