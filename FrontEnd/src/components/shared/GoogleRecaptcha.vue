<!-- <template>
  <div>
    <vue-recaptcha @verify="onCaptchaVerified" @expired="onCaptchaExpired" ref="recaptcha"></vue-recaptcha>
  </div>
</template>

<script>
import VueRecaptcha from "vue-recaptcha";

export default {
  name: 'GoogleRecaptcha',
  methods: {
    onCaptchaVerified(token) {
      console.log("reCAPTCHA verified:", token);
     // 在這裡可以執行驗證成功後的操作

      $.post(`${GetApiUrl()}/login/Robot`,
        {
          token: token,
        }, function (rr) {
          console.log(rr);
          if (rr.result == "success") {
            console.log("機器人成功")
          } else {
            console.log("機器人失敗")
          }
        })

      
    },
    onCaptchaExpired() {
      console.log("reCAPTCHA expired");

      // 在這裡可以處理 reCAPTCHA 過期事件
    },
  },
  components: {
    VueRecaptcha,
  },
}
</script> -->
<template>
  <div id="divR" class="g-recaptcha"></div>
</template>
<script>

export default {
  name: 'GoogleRecaptcha',

  mounted() {
    const recaptchaScript = document.createElement('script');
    recaptchaScript.src = 'https://www.google.com/recaptcha/api.js?onload=onLoadCallback&render=explicit';
    recaptchaScript.async = true;
    recaptchaScript.defer = true;
    document.head.appendChild(recaptchaScript);

  }

}
</script>