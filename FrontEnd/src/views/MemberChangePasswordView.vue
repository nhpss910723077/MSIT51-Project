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
                  <div class="title">密碼修改</div>
                  <div class="passwordUpdate">
                    <label for="originalPassword">*舊密碼：</label>
                    <div class="NewPassword">
                      <input type="password" id="originalPassword" placeholder="請輸入舊密碼">
                    </div>

                    <label for="NewPassword">*新密碼：</label>
                    <div class="NewPassword">
                      <input type="password" id="NewPassword" placeholder="請輸入新密碼">
                      <div v-if="NewPasswordWarning" id="NewPasswordWarning">
                        密碼格式不符!密碼必須包含至少一個數字、一個英文字母，且長度至少8碼。
                      </div>
                    </div>

                    <label for="PasswordConfirm">*再次確認密碼：</label>
                    <div class="PasswordConfirm">
                      <input type="password" id="PasswordConfirm" placeholder="請再次輸入新密碼">
                      <div v-if="PasswordConfirmWarning" id="PasswordConfirmWarning">輸入密碼不相同!</div>
                      <div class="dataUpdateSubmitBtn">
                        <button class="btn bg2btn" type="submit" @click="dataUpdateSubmit()">送出
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
  name: 'MemberChangePasswordView',
  data() {
    return {
      MemberID: parseInt(sessionStorage.getItem('MemberID')),
      breadCrumbData: [
        { title: "首頁", link: "/" },
        { title: "會員中心", link: "/member/index" },
        { title: "密碼修改", link: "" },
      ],
      PageMenuData: {
        menuName: "會員中心",
        menuLink: "/member/index",
        menuData: []
      },
      updateData: {},
      // MenuList: [],
      NewPasswordWarning: false,
      PasswordConfirmWarning: false,
    }
  },
  methods: {
    // addClass: function (href) {
    //   var f = href.split("./");
    //   console.log(window.location.href);
    //   console.log(f[f.length - 1]);
    //   console.log(window.location.href.indexOf(f[f.length - 1]));

    //   if (window.location.href.indexOf(f[f.length - 1]) > 0) {
    //     return true;
    //   } else {
    //     return false;
    //   }
    //   // return false;
    // },
    dataUpdateSubmit() {
      var self = this;
      // post成功後alert
      self.NewPasswordWarning = self.PasswordConfirmWarning = false;
      // document.querySelector("#NewPasswordWarning").textContent = "";
      // document.querySelector("#PasswordConfirmWarning").textContent = "";

      var NewPassword = document.querySelector("#NewPassword").value;
      var passwordPattern = /^(?=.*\d)(?=.*[a-zA-Z])[0-9a-zA-Z]{8,}$/;
      var PasswordConfirm = document.querySelector("#PasswordConfirm").value;

      if (!passwordPattern.test(NewPassword)) {
        self.NewPasswordWarning = true;
        // return;
      } else if (NewPassword != PasswordConfirm) {
        self.PasswordConfirmWarning = true;
        // return;
      } else {
        $.ajax({
          method: "POST",
          dataType: 'JSON',
          url: `${GetApiUrl()}/member/PasswordUpdate/${self.MemberID}`,
          data: {
            originalPassword: document.querySelector("#originalPassword").value,
            NewPassword: document.querySelector("#NewPassword").value,
          },
          mode:"cors",
        }).done(function (updateResult) {
          console.log(updateResult)
          Swal.fire({

            title: updateResult.title,
            icon: updateResult.result,
            timer: 2000,
            showConfirmButton: false,

          });
          setTimeout(
            function () {
              window.location.href = window.location.href
            }, 2000
          )
        });
      }


    },
  },
  async created() {
    var self = this;
    // 取得資料
    // try {
    //   $.ajax({
    //     method: "GET",
    //     dataType: "JSON",
    //     url: `${GetApiUrl()}/member/EditDataUpdate`
    //   }).done(function (data) {
    //     self.updateData = data;
    //     console.log(self.updateData);
    //   })
    // } catch (error) {
    //   console.log("發生錯誤");
    // }

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