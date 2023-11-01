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
                    <div class="flexContainer step3">
                      <p>Step.3</p>
                      <div class="font-sm flexContainer">
                        <div class="flexContainer">賣出後的收益轉為：</div>
                        <div class="flexContainer"><label><input type="radio" name="step3WithdrawType.WithdrawType"
                              v-model="step3WithdrawType.WithdrawType" value="ShoppingMoney" > 購書金
                          </label></div>
                        <div class="flexContainer"><label><input type="radio" name="step3WithdrawType.WithdrawType"
                              v-model="step3WithdrawType.WithdrawType" value="Remit" > 提領至銀行帳戶</label>
                        </div>

                        <transition name="slideDown">
                          <div class="RemitInfo flexContainer " v-show="step3WithdrawType.WithdrawType == 'Remit'">
                            <hr>
                            <div class="flexContainer">帳戶資訊：</div>
                            <div class="flexContainer"><label for="name">戶名：</label><input type="text" id="name"
                                v-model="step3WithdrawType.RemitAccount.RemitName" placeholder="請輸入帳戶的姓名"></div>
                            <div class="flexContainer"><label for="bankCode">銀行代碼：</label><input type="text" id="bankCode"
                                v-model="step3WithdrawType.RemitAccount.bankCode" placeholder="請輸入銀行代碼"></div>
                            <div class="flexContainer"><label for="account">帳號：</label><input type="text" id="account"
                                v-model="step3WithdrawType.RemitAccount.account" placeholder="請輸入帳號"></div>
                            <hr>
                          </div>
                        </transition>
                        <div class="flexContainer">
                          <input type="checkbox" disabled="true" class="checked-btn" id="read"> <label
                            for="read">&nbsp;已閱讀
                            <a @click="usedSalePolicy" href="/member/policy" target="_blank">二手書販售須知</a></label>
                        </div>
                      </div>

                      <div class="flexContainer submitBtnCenter">

                        <button class="btn font-sm bg2btn" @click="toStep2()">
                          上一步
                        </button>

                        <button id="apply" class="btn font-sm bg1btn" @click="UsedSaleInsert()">
                          送出
                        </button>
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
  name: 'MemberUsedBookStep2View',
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
      step2UsedBookList: [],
      step3WithdrawType: {
      WithdrawType: "ShoppingMoney",
      RemitAccount: {
        RemitName: "",
        bankCode: "",
        account: ""
      }
    },

      // MenuList: []
    }
  },
  methods: {
    // test() {
    //   var self = this;
    //   console.log(self.step3WithdrawType.WithdrawType);
    // },
    toStep2() {
      var self = this;
      localStorage.setItem("step2UsedBookList", JSON.stringify(self.step2UsedBookList))
      localStorage.setItem("step3WithdrawType", JSON.stringify(self.step3WithdrawType))
      window.location.href = '/member/usedBookStep1'


    },
    usedSalePolicy() {
      const readElement = document.querySelector("#read");
      if (readElement.hasAttribute("disabled")) {
        readElement.removeAttribute("disabled");
      }
    },
    UsedSaleInsert() {
      var self = this;
      for (let index = 0; index < self.step2UsedBookList.length; index++) {
        self.step2UsedBookList[index].WithdrawType = self.step3WithdrawType.WithdrawType;
        if(self.step3WithdrawType.WithdrawType == "Remit"){
          self.step2UsedBookList[index].RemitAccount = 
          self.step3WithdrawType.RemitAccount.RemitName+
          self.step3WithdrawType.RemitAccount.bankCode+
          self.step3WithdrawType.RemitAccount.account;
        }
      }
      console.log(self.step2UsedBookList);
      $.ajax({
        method: "POST",
        dataType: 'JSON',
        url: `${GetApiUrl()}/member/UsedSaleInsert`,
        data: self.step2UsedBookList
      }).done(function (data) {
        console.log(data);
        Swal.fire({
          title: data.tittle,
          icon: data.result,
          // text: "將於收件審核後上架",
          timer: 3000000,
          showConfirmButton: false,
          text: data.text,
        });
        setTimeout(function () {
          if (data.result == "success") {
            console.log(data);
            localStorage.clear();
            // window.location.href = '/member/usedBookStep3';
          } else {
            console.log(data);
            // window.location.href = window.location.href;
          }
        }, 3000000)

      });
    },

  },
  async created() {
    var self = this;
    // localStorage
    if (localStorage.getItem("step2UsedBookList") != null) {
      self.step2UsedBookList = JSON.parse(localStorage.getItem("step2UsedBookList"));
    }
    if (localStorage.getItem("step3WithdrawType") != null) {
      self.step3WithdrawType = JSON.parse(localStorage.getItem("step3WithdrawType"));
    }

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

    // $("body").on("click", "#apply", function () {
    //   Swal.fire({
    //     title: '申請完成',
    //     icon: 'success',
    //     // text: "將於收件審核後上架",
    //     timer: 3000,
    //     showConfirmButton: false,
    //     text: "將於收件審核完成後上架"
    //   });
    //   setTimeout(function () {
    //     window.location.href = "./member_secondHandBookP3.html"
    //   }, 3000)

    // })
  },
  components: {
    TopBanner,
    BreadCrumb,
    PageMenu,
  }
}
</script>

<style scoped src="./css/Member.css"></style>