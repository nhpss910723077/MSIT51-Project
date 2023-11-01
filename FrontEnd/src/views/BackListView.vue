<template>
  <div class="page">
    <backMenu></backMenu>
    <div class="content-wrap">
      <div class="container-xl">
        <div class="content">
          <div class="row">
            <backTitle :title="pageData.title"></backTitle>

            <div class="col-12" v-if="pageData.creatable">
              <div class="back-list-create-wrap">
                <router-link :to="`/back/create/${$route.params.modelName}`" class="btn btn-primary">新增</router-link>
              </div>
            </div>

            <form id="search" @submit.stop.prevent="submit">
              <div class="row back-search-wrap">
                <template v-for="(item, index) in searchFieldData">
                  <component :is="getTag(item.Type)" :index="index" :field="item" :content="searchData">
                  </component>
                </template>
              </div>
            </form>

            <div class="col-12">
              <table class="table list-wrap">
                <thead class="table-dark">
                  <tr>
                    <th width="100px">編號</th>
                    <template v-for="(item, index) in fieldData">
                      <th>{{ item.Name }}</th>
                    </template>
                    <th width="100px">狀態</th>
                    <th width="100px">操作</th>
                  </tr>
                </thead>
                <tbody>
                  <tr v-for="(ld, ldi) in listData">
                    <th>{{ ldi + 1 }}</th>
                    <template v-for="(item, index) in fieldData">
                      <th>
                        <component :is="getTag(item.Type)" :index="index" :field="item" :content="ld">
                        </component>
                      </th>
                    </template>
                    <th class="back-enable">
                      <template v-if="ld['item']['Enable']">
                        <i class="fa-solid fa-o"></i>
                      </template>
                      <template v-else>
                        <i class="fa-solid fa-x"></i>
                      </template>
                    </th>
                    <th class="operation">
                      <router-link :to="`/back/edit/${$route.params.modelName}/${ld['item'].ID}`" class="box">
                        <i class="fa-solid fa-pen-to-square"></i>
                      </router-link>
                      <div class="box" @click="DeleteItem(ld['item'].ID)" v-if="pageData.deletable">
                        <i class="fa-solid fa-trash"></i>
                      </div>
                    </th>
                  </tr>
                </tbody>
              </table>
            </div>

            <div class="col-12">
              <BackPagination></BackPagination>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import backMenu from '@/components/back/BackMenu.vue'
import backTitle from '@/components/back/BackTitle.vue'
import BackPagination from '@/components/back/BackPagination.vue'
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
  name: 'BackListView',
  components: {
    backMenu,
    backTitle,
    BackPagination,
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
      searchFieldData: [],
      searchData: [],
      listData: [],
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
    DeleteItem: function (id) {
      let self = this;

      Swal.fire({
        title: "是否確定刪除",
        icon: "info",
        showConfirmButton: true,
        showCancelButton: true,
        confirmButtonText: "是",
        cancelButtonText: "否",
        showCloseButton: false, // 隐藏右上角的关闭按钮
      }).then((result) => {
        if (result.isConfirmed) {
          $.ajax({
            method: "POST",
            dataType: 'JSON',
            url: `${GetApiUrl()}/Back/Delete${self.$route.params.modelName}ByID/${id}`,
            data: {
              __RequestVerificationToken: Cookies.get('XSRF-TOKEN'),
            },
          })
            .done(function (data) {
              Swal.fire({
                title: data.title,
                icon: data.result,
                timer: 2000,
                showConfirmButton: false,
              }).then(function () {
                self.GetPage();
              });
            })
            .fail(function (data) {
              alert("發生錯誤");
            });
        }
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
          url: `${GetApiUrl()}/Back/Get${self.$route.params.modelName}ListData${location.search}`,
        })
          .done(function (data) {
            self.listData = data;
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
          url: `${GetApiUrl()}/Back/Get${self.$route.params.modelName}ListFieldData`,
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

      // 取得搜尋欄位資料
      try {
        await $.ajax({
          method: "get",
          url: `${GetApiUrl()}/Back/Get${self.$route.params.modelName}ListSearchFieldData`,
        })
          .done(function (data) {
            self.searchFieldData = data.searchFieldData;
            self.searchData = data.searchData;
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

<style scoped src="./css/Back.css"></style>
<style scoped>
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

.list-wrap {
  width: 100%;
  font-size: 20px;
}

.list-wrap.table>:not(caption)>*>* {
  padding: 0.65rem;
}

.operation .box {
  display: inline-block;
  margin-right: 10px;
  color: rgb(152, 185, 217);
  cursor: pointer;
}

.back-enable .fa-o {
  color: green;
  font-size: 30px;
  font-weight: bold;
}

.back-enable .fa-x {
  color: red;
  font-size: 30px;
  font-weight: bold;
}

.back-list-create-wrap {
  display: flex;
  justify-content: flex-end;
  padding-bottom: 10px;
}

.back-search-wrap {
  display: flex;
  justify-content: flex-start;
  align-items: center;
  flex-wrap: wrap;
}
</style>