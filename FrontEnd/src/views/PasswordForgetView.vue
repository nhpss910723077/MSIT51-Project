<template>
  <section class="bgcolor">
    <BreadCrumb :data="breadCrumbData" />
  </section>

  <section id="app2" class="min-height bgcolor">
    <img class="Fbg" :src="`/images/tree3.png`">
    <div class="container goup">
      <div class="row">
        <div class="col-sm-1 col-md-2"></div>

        <div class="col-sm-10 col-md-8">
          <div class="mytitle">
            <div>——</div>
            <div>忘記密碼</div>
            <div>——</div>
          </div>



          <div class="row">
            <div class="col-3"> <label for="email">電子郵件:</label></div>
            <div class="col-9"> <input id="email" type="email" required></div>



            <GoogleRecaptcha />
            <div id="robotF">
              <div class="g-recaptcha" data-sitekey="6LeF5lwoAAAAAJL0gcsnMnyzuekvEdbQFBrySFDG" data-size="normal"
                data-callback="verify" data-expired-callback="expired" data-error-callback="error"></div>
            </div>

            <div class="d-grid gap-2"> <button @click="sure()" class="DarkGbtn">確認</button></div>

          </div>




        </div>

        <div class="col-sm-1 col-md-2"></div>



      </div>
    </div>
  </section>
</template>

<script>

import BreadCrumb from '@/components/shared/BreadCrumb.vue'
//import GoogleRecaptcha from '@/components/shared/GoogleRecaptcha.vue'

export default {
  name: 'PasswordForgetView',
  data() {
    return {
      breadCrumbData: [
        { title: "首頁", link: "/" },
        { title: "忘記密碼", link: "" },
      ],
    }
  },
  methods: {
    sure: function (tagName) {
      //驗證欄位格式
      var regex1 = new RegExp("[0-9a-zA-Z_]+([.-][0-9a-zA-Z_]+)*@[0-9a-zA-Z_]+([.-][0-9a-zA-Z_]+)+");
      if (!regex1.test(email.value)) {

        Swal.fire({
          icon: 'error',
          title: '申請失敗!',
          text: '會員信箱格式錯誤',
        })
        return;
      }

      //寄新密碼到信箱
      $.post(`${GetApiUrl()}/login/ForgetPwd`,
        { userEmail: email.value },
        function (rr) {
          console.log(rr);



          if (rr.result == "success") {
            Swal.fire(
              '申請成功!',
              '已收到您的申請，請至您的Email收取新密碼。',
              'success'
            );



          }
          else {
            Swal.fire({
              icon: 'error',
              title: '申請失敗!',
              text: '會員信箱輸入錯誤',
            })
          }
        })


    },
  },
  async created() {
    var self = this;

  

    // 取得資料
    try {

    } catch (error) {
      console.log("發生錯誤");
    }
  },
  components: {
    BreadCrumb,
    //GoogleRecaptcha,
  }
}
</script>

<style scoped src="./css/Login&news.css"></style>