<template>
  <TopBanner />
  <section>
    <BreadCrumb :data="breadCrumbData" />
  </section>

  <section>
    <div class="container">
      <div class="row">
        <PageMenu :data="PageMenuData" />
        <div class="col-ms-12 col-lg-9">
          <!-- <div style="background-color:lightblue; height: 200px;"> -->
          <div>
            <div>
              <div class="memberContent" v-if="updateData != null">
                <div class="Content">
                  <div class="title">會員資料修改</div>
                  <div class="dataUpdate">
                    <label>電子郵件：</label><span>{{ updateData.Account }}</span><br>
                    <p></p>
                    <label for="userName">*姓名：</label><input type="text" id="userName" placeholder="請輸入姓名"
                      v-model=updateData.Name><br>
                    <p></p>
                    <label for="NickName">暱稱：</label><input type="text" id="NickName" placeholder="請輸入暱稱"
                      v-model=updateData.NickName><br>
                    <p></p>
                    <label for="phoneNumber">*手機號碼：</label><input type="text" id="phoneNumber" placeholder="請輸入手機號碼"
                      v-model="updateData.Phone"><br>
                    <!-- <div>{{updateData.Phone}}</div> -->
                    <p></p>

                    <!-- !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! -->

                    <div id="twzipcode">
                      <span>地址：</span>
                      <div class="location">

                        <div data-role="zipcode" data-style="form-select" ref="zipcodeRef" @change="locationChange()">
                        </div>
                        <div data-role="county" data-style="form-select" ref="countyRef" @change="locationChange()">
                        </div>
                        <div data-role="district" data-style="form-select" ref="districtRef" @change="locationChange()">
                        </div>
                        <input id="address_detail" type="text" v-model="updateData.Address">

                      </div>
                    </div>
                    <!-- !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! -->


                    <p></p>
                    <div class="Gender">
                      <div>&nbsp;性別：</div>
                      <div class="GenderOption">
                        <div><input id="boy" type="radio" name="Gender" value="0" v-model="updateData.Gender">
                          <label for="boy"><span>男性</span></label>
                        </div>
                        <div><input id="girl" type="radio" name="Gender" value="1" v-model="updateData.Gender">
                          <label for="girl"><span>女性</span></label>
                        </div>
                        <div><input id="noreply" type="radio" name="Gender" value="2" v-model="updateData.Gender">
                          <label for="noreply"><span>不提供</span></label>
                        </div>
                      </div>
                    </div>

                    <p></p>
                    <div class="birth">
                      <label for="Birth">&nbsp;生日：</label>
                      <input type="text" id="Birth" v-model="updateData.Birthday"><br><br>
                      
                      <!-- <div>{{updateData.Birthday}}</div> -->
                    </div>

                    <div class="dataUpdateSubmitBtn"><button class="btn btn-lg bg2btn" @click="dataUpdateSubmit()"
                        type="submit">送出</button></div>

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
  name: 'MemberUpdateView',
  data() {
    return {
      MemberID: parseInt(sessionStorage.getItem('MemberID')),
      breadCrumbData: [
        { title: "首頁", link: "/" },
        { title: "會員中心", link: "/member/index" },
        { title: "會員資料修改", link: "" },
      ],
      PageMenuData: {
        menuName: "會員中心",
        menuLink: "/member/index",
        menuData: []
      },
      updateData: {},
      // MenuList: [],
    }
  },
  methods: {
    // 地址更新至vue_data_updateData

    locationChange: function () {
      var self = this;
      self.updateData.ZipCode = self.$refs.zipcodeRef.children[0].value;
      self.updateData.County = self.$refs.countyRef.children[0].value;
      self.updateData.District = self.$refs.districtRef.children[0].value;
      console.log(self.updateData.ZipCode)
    },
    // 會員資料更新
    dataUpdateSubmit() {
      var self = this;
      $.ajax({
        method: "POST",
        dataType: 'JSON',
        url: `${GetApiUrl()}/member/EditDataUpdate/${self.MemberID}`,
        data: self.updateData
      }).done(function (updateResult) {
        console.log(updateResult)
        Swal.fire({

          title: updateResult.title,
          icon: updateResult.result,
          timer: 2000,
          showConfirmButton: false,

        });
        setTimeout(function () {
          window.location.href = window.location.href
        }, 2000);

      });
    }

  },mounted() {
    var self = this;

    $("#Birth").datepicker({
      dateFormat: "yy-mm-dd",
      regional: "zh-TW",
    });
  },
  async created() {
    var self = this;


    
    // get 會員資料
    try {
      $.ajax({
        method: "GET",
        dataType: 'JSON',
        url: `${GetApiUrl()}/member/dataupdate/${self.MemberID}`,
      }).done(function (data) {
        
        self.updateData = data;
        if(self.updateData.Birthday!=null){
          self.updateData.Birthday =  self.updateData.Birthday.split("T")[0];
        }
        

        console.log(self.updateData);
        $('#twzipcode').twzipcode({
          'countySel': self.updateData.County,
          'districtSel': self.updateData.District,
        });


      });
    } catch (error) {
      console.log("發生錯誤");
    }

    // get 會員menu資料
    try {
      $.ajax({
        method: "GET",
        dataType: 'JSON',
        url: `${GetApiUrl()}/member/MemberMenu/${self.MemberID}`,
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

<!-- <style scoped src="./css/Member.css"></style> -->
<style  src="./css/Member.css"></style>