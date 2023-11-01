<template>
  <div class="page">
    <backMenu></backMenu>
    <div class="content-wrap">
      <div class="container-xl">
        <div class="content">
          <form id="form">
            <div class="row">
              <backTitle :title="pageData.title"></backTitle>

              <template v-for="(item, index) in fieldData" >
                <component :is="getTag(item.Type)" :index="index" :field="item" :content="contentData">
                </component>
              </template>

              <div class="col-12">
                <div class="back-btn-wrap">
                  <input type="hidden" name="__RequestVerificationToken" />
                  <button type="button" class="btn btn-danger" @click="BackPage">回上頁</button>
                  <button type="button" class="btn btn-primary" @click="SendForm">送出</button>
                </div>
              </div>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import backMenu from '@/components/back/BackMenu.vue'
import backTitle from '@/components/back/BackTitle.vue'
import back0 from '@/components/back/BackText.vue'
import back1 from '@/components/back/BackImg.vue'
import back2 from '@/components/back/BackInput.vue'
import back3 from '@/components/back/BackNumber.vue'
import back4 from '@/components/back/BackTextarea.vue'
import back5 from '@/components/back/BackSelect.vue'
import back6 from '@/components/back/BackFile.vue'
import back7 from '@/components/back/BackDatepicker.vue'
import back8 from '@/components/back/BackSwitch.vue'
import back9 from '@/components/back/BackSort.vue'
import back10 from '@/components/back/BackOX.vue'
import back11 from '@/components/back/BackISBN.vue'
import back12 from '@/components/back/BackOrderDetail.vue'
import back13 from '@/components/back/BackSearchInput.vue'
import back14 from '@/components/back/BackSearchSelect.vue'

export default {
  name: 'BackContentView',
  components: {
    backMenu,
    backTitle,
    back0,
    back1,
    back2,
    back3,
    back4,
    back5,
    back6,
    back7,
    back8,
    back9,
    back10,
    back11,
    back12,
    back13,
    back14,
  },
  data() {
    return {
      pageData: {},
      fieldData: [],
      contentData: [],
    }
  },
  watch: {
    '$route'(to, from) {
      this.GetPage();
    }
  },
  methods: {
    getTag: function (tagName) {
      return "back" + tagName;
    },
    BackPage: function () {
      history.back()
    },
    SendForm: function (event) {
      let self = this;

      let currentBtn = $(event.target);
      if (currentBtn.hasClass('sending')) return;
      currentBtn.addClass('sending');

      $("input[name='__RequestVerificationToken']").val(Cookies.get('XSRF-TOKEN'));
      var data = new FormData($('#form')[0]);

      let url;
      if (self.$route.name === "backEdit") {
        url = `${GetApiUrl()}/Back/Edit${self.$route.params.modelName}ContentData/${self.$route.params.id}`;
      } else {
        url = `${GetApiUrl()}/Back/Create${self.$route.params.modelName}ContentData`;
      }

      $.ajax({
        method: "POST",
        dataType: 'JSON',
        enctype: 'multipart/form-data',
        url: url,
        data: data,
        cache: false,
        processData: false,
        contentType: false,
      })
        .done(function (data) {
          currentBtn.removeClass('sending');

          Swal.fire({
            title: data.title,
            icon: data.result,
            timer: 2000,
            showConfirmButton: false,
          }).then(function () {
            if (data.result === "success") {
              if (self.$route.name === "backEdit") {
                setTimeout(function () {
                  scrollTo(0, 0);
                  self.GetPage();
                }, 200);
              } else {
                self.$router.push(`/back/edit/${self.$route.params.modelName}/${data.ID}`);
              }
            }
          });

          console.log(data);
        })
        .fail(function (data) {
          currentBtn.removeClass('sending');
          alert("發生錯誤");
        });
    },
    GetPage: async function () {
      let self = this;

      // 取得頁面設定
      try {
        $.ajax({
          method: "get",
          url: `${GetApiUrl()}/Back/Get${self.$route.params.modelName}PageData/${self.$route.params.id}`,
        })
          .done(function (data) {
            self.pageData = data;
          })
          .fail(function (data) {
            console.log("無法取得資料");
          });
      } catch (error) {
        console.log("發生錯誤");
      }

      // 取得資料
      try {
        await $.ajax({
          method: "get",
          url: `${GetApiUrl()}/Back/Get${self.$route.params.modelName}ContentData/${self.$route.params.id}`,
        })
          .done(function (data) {
            self.contentData = data;
            console.log(data);
          })
          .fail(function (data) {
            console.log("無法取得資料");
          });
      } catch (error) {
        console.log("發生錯誤");
      }

      // 取得欄位資料
      try {
        await $.ajax({
          method: "get",
          url: `${GetApiUrl()}/Back/Get${self.$route.params.modelName}ContentFieldData`,
        })
          .done(function (data) {
            self.fieldData = data;
          })
          .fail(function (data) {
            console.log("無法取得資料");
          });
      } catch (error) {
        console.log("發生錯誤");
      }
    },
  },
  async created() {
    this.GetPage();
  },
}
</script>

<style scoped >
/* ===== 內頁 ===== */
.page {
  display: flex;
  min-height: 600px;
  justify-content: center;
  align-items: stretch;
  flex-wrap: wrap;
}

.content-wrap {
  width: calc(100% - 300px);
  padding: 37.5px 25px;
  background-color: #F5F5F5;
}

.content {
  width: 100%;
  padding: 40px;
  border-radius: 5px;
  background-color: white;
  box-shadow:
    0px 2px 1px -1px rgba(0, 0, 0, 0.2),
    0px 1px 1px 0px rgba(0, 0, 0, 0.14),
    0px 1px 3px 0px rgba(0, 0, 0, 0.12);
}

.back-btn-wrap {
  display: flex;
  justify-content: flex-end;
  padding-top: 50px;
}

.back-btn-wrap .btn {
  margin-left: 15px;
}
</style>