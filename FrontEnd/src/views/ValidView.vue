<template>
  <div class="valid-page"></div>
</template>

<script>
export default {
  name: 'ValidView',
  props: [],
  async created() {
    var self = this;
    
    var memberID = self.$route.params.memberID;
    var vcode = self.$route.params.vcode;
    //console.log(memberID);
    //console.log(vcode);
    
    // 取得資料
    try {

      $.get(`${GetApiUrl()}/login/DOverify?memberID=${memberID}&vcode=${vcode}`,
            function (rr) {
                console.log(rr);

                if (rr.result == "success") {
                    Swal.fire({
                        title: '驗證成功!',
                        text: '即將前往登入頁面',
                        icon: 'success',              
                    }
                    ).then(
                        function(result){if (result.value) {
                        location.href="/login";}
                    })


                }

                else {
                    Swal.fire({
                        icon: 'error',
                        title: '驗證失敗!',
                        text: '請重新驗證',
                    })
                }
            })
    } catch (error) {
      console.log("發生錯誤");
    }
  }
}
</script>

<style scoped src="./css/Login&news.css"></style>
<style scoped>
.valid-page{
  min-height: 400px;
}
</style>