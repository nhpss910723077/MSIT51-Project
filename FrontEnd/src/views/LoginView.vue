<template>
  <section class="bgcolor">
    <BreadCrumb :data="breadCrumbData" />
  </section>

  <section id="app2" class="bgcolor">
    <div class="container">
      <div class="row" id="switch">
        <div class="col-lg-12 col-xl-7">
          <div class="duck">
            <img :src="`/images/鴨鴨2.jpeg`" alt="登入大圖">
          </div>
        </div>
        <div class=" col-lg-12 col-xl-5">
          <div class="mytitle">
            <div>—</div>
            <div>現有帳號登入</div>
            <div>—</div>
          </div>
          <div class="DivL">
            <img src="/images/FACEBOOK.png" alt="fb" class="loginIMG">
          </div>
            <!-- Google登入-->
            <div class="DivL">
              <div id="g_id_onload"
                data-client_id="690485256476-prlr7d5h1ubdnapv8fkthmls92nlab9h.apps.googleusercontent.com"
                data-callback="handleCallback" data-auto_prompt="false"></div>
              <div class="g_id_signin" data-type="standard" data-size="large" data-theme="outline"
                data-text="sign_in_with" data-shape="rectangular" data-logo_alignment="left" data-width="400"></div>
            </div>

         

          <br>
          <div class="mytitle">
            <div>—</div>
            <div>ReadUse會員登入</div>
            <div>—</div>
          </div>

          <div class="row">
            <div class="col-4"><label for="email" id="text">會員信箱:</label></div>
            <div class="col-8"><input id="email" type="email" placeholder="(請輸入電子信箱)"
                pattern="\w+([\.\-]\w+)*@\w+([\.\-]\w+)+" required></div>
            <div class="col-4"><label for="password">會員密碼:</label></div>
            <div class="col-8"><input id="password" type="password" placeholder="(請輸入密碼)"
                pattern="(?=.*\d)(?=.*[a-zA-Z])[0-9a-zA-Z]{8,}" required>
            </div>

            <!--我不是機器人-->
            <div class="robot">
              <div class="robot1"></div>
              <div class="robot2">
                <GoogleRecaptcha />
              </div>
            </div>
            <br>
            <br>
            <br>
            <br>
            <div class="d-grid gap-2">
              <button class="DarkGbtn" @click="Login">登入</button>
            </div>
          </div>
          <br>
          <div class="row">

            <div class="col-5 bt1"> <a href="/register">註冊</a></div>
            <div class="col-2 bt2">|</div>
            <div class="col-5 bt3"><a href="/password/forget">忘記密碼</a></div>
          </div>
          <br><br>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
import BreadCrumb from '@/components/shared/BreadCrumb.vue'
import GoogleRecaptcha from '@/components/shared/GoogleRecaptcha.vue'

export default {
  name: 'LoginView',
  data() {
    return {
      breadCrumbData: [
        { title: "首頁", link: "/" },
        { title: "會員登入", link: "" },
      ],
    }
  },
  methods: {

    Login: function () {
      let self = this;

      //recaptcha機器人檢查
      if (!document.cookie.includes("RobotTest")) {
        Swal.fire({
          icon: 'error',
          title: '登入失敗!',
          text: '未通過機器人測試',
        })
        return;
      };

      //驗證欄位格式
      var regex1 = new RegExp("[0-9a-zA-Z_]+([.-][0-9a-zA-Z_]+)*@[0-9a-zA-Z_]+([.-][0-9a-zA-Z_]+)+");
      if (!regex1.test(email.value)) {

        Swal.fire({
          icon: 'error',
          title: '登入失敗!',
          text: '會員信箱格式錯誤',
        })
        return;
      }
      var regex2 = new RegExp("(?=.*[0-9])(?=.*[a-zA-Z])[0-9a-zA-Z]{8,}");
      if (!regex2.test(password.value)) {

        Swal.fire({
          icon: 'error',
          title: '登入失敗!',
          text: '密碼格式錯誤',
        })
        return;
      }

      $.post(`${GetApiUrl()}/login/DoLogin`,
        {
          userEmail: email.value,
          userPassword: password.value,
          bindCode: self.$route.query.bindCode
        }, function (rr) {
          console.log(rr);

          if (rr.result == "success") {
            Swal.fire({
              title: rr.title,
              text: '即將前往會員中心。',
              icon: 'success',
              showConfirmButton: false,
            })
            setTimeout(function () { location.href = "/member/index" }, 3000);

            //把會員ID加到sessionStorage
            sessionStorage.setItem("MemberID", rr.MemberID);
          }
          else if(rr.result == "validerror") {
            Swal.fire({
              icon: 'error',
              title: '登入失敗!',
              text: '此帳號尚未開通',
            })
          }
          else {
            Swal.fire({
              icon: 'error',
              title: '登入失敗!',
              text: '請輸入正確的會員信箱及密碼',
            })
          }
        })
    },

  },
  mounted() {
    // Google快速登入
    const googleScript = document.createElement('script');
    googleScript.src = 'https://accounts.google.com/gsi/client';
    googleScript.async = true;
    googleScript.defer = true;
    document.head.appendChild(googleScript);
  },
  async created() {
    var self = this;
    try {

    } catch (error) {
      console.log("發生錯誤");
    }
  },
  components: {
    BreadCrumb,
    GoogleRecaptcha,
  }
}


</script>

<style scoped src="./css/Login&news.css"></style>