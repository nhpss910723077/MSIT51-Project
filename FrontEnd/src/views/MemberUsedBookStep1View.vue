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
                  <div class="flexContainer secondHandBook ">
                    <div class="flexContainer step1 steps" v-show=Step1show>
                      <p>Step.1</p>
                      <div class="font-sm flexContainer">
                        <label for="ISBNInput">請輸入二手書的ISBN碼： </label>
                        <input type="text" id="ISBNInput" placeholder="請輸入ISBN碼">&nbsp;
                        <button type="submit" class="btn font-sm bg1btn" @click="Step1BookSearch()">新增</button>
                      </div>
                    </div>

                    <div class="flexContainer step2 steps" v-show="Step2show">
                      <p>Step.2</p>
                      <div class="font-sm flexContainer">請輸入二手書的售價、書況，並上傳1-3張書況照片： </div>
                      <div class="flexContainer steps">
                        <table class="font-sm myListTable myListTable5 flexContainer">
                          <tr class="flexContainer firstTr">
                            <th>ISBN</th>
                            <th>書名</th>
                            <th>售價</th>
                            <th>書況評估</th>
                            <th>書況照片</th>
                          </tr>

                          <tr class="flexContainer" v-for="(item, index) in step2UsedBookList">
                            <td v-if="item.ISBN13!=''" class="flexContainer">{{ item.ISBN13 }}</td>
                            <td v-if="!item.ISBN13!=''" class="flexContainer">{{ item.ISBN10 }}</td>
                            <td class="flexContainer">
                              <div class="txtshort" :title="item.ProductName">
                                {{ item.ProductName }}</div>
                            </td>
                            <td class="flexContainer"><input type="number" class="SalePriceInput priceInput"
                                v-model="item.SalePrice" placeholder="自訂售價"></td>
                            <td class="flexContainer">
                              <select name="BookStatus" id="BookStatus" v-model="item.BookStatus">
                                <option disabled selected>請選擇分級</option>
                                <option value="0">全新</option>
                                <option value="1">良好</option>
                                <option value="2">有註記</option>
                              </select>
                            </td>
                            <td class="flexContainer">
                              <button class="btn font-sm bg1btn" uploaded=false :id="'insertPhotoBtn' + index"
                                :data-bs-target="'#insertPhoto' + index" data-bs-toggle="modal">待上傳</button>
                            </td>
                            <!-- 照片上傳 -->
                            <div class="modal fade font-sm" :id="'insertPhoto' + index" data-bs-backdrop="static"
                              data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel"
                              aria-hidden="true">
                              <div class="modal-dialog modal-lg modal-dialog-centered">
                                <div class="modal-content">
                                  <div class="modal-header">
                                    <h5 class="modal-title font-sm" style="padding: 10px;" id="staticBackdropLabel">書況圖片上傳
                                    </h5>
                                    <button type="button" class="btn-close closebtn" data-bs-dismiss="modal"
                                      aria-label="Close"></button>
                                  </div>
                                  <div class="modal-body ">
                                    <div class="flexContainer">
                                      <div class="input-box-file  flexContainer">
                                        <div class="flexContainer">
                                          <span class="photoInsert">書名</span>
                                          <div class="photoInsert">{{ item.ProductName }}</div>
                                        </div>
                                        <div class="flexContainer ">
                                          <form class="flexContainer" :id="'form' + index">
                                            <label class="control-label photoInsert" for="Imgs">書況照片新增</label>
                                            <input multiple type="file" class="form-control photoInsert" id="Imgs"
                                              name="Imgs" @change="DisplayImg(index, $event)">
                                            <div class="flexContainer steps"></div>
                                            <div class="input-box-file-img flexContainer">
                                              <img class="photoInsert" :class="`img${index}`" src="" alt="">
                                              <img class="photoInsert" :class="`img${index}`" src="" alt="">
                                              <img class="photoInsert" :class="`img${index}`" src="" alt="">
                                            </div>
                                            <!-- hidden -->
                                            <input type="text" hidden name="MemberID" v-model="item.MemberID">
                                            <input type="text" hidden name="ProductID" v-model="item.ProductID">
                                            <input type="text" hidden name="ProductName" v-model="item.ProductName">
                                            <input type="text" hidden name="SalePrice" v-model="item.SalePrice">
                                            <input type="text" hidden name="WithdrawType"
                                              v-model="step3WithdrawType.WithdrawType">
                                            <input type="text" hidden name="BookStatus" v-model="item.BookStatus">
                                            <input type="text" hidden name="VerifyStatus" v-model="item.VerifyStatus">
                                            <input type="text" hidden name="RemitAccount" v-model="item.RemitAccount">
                                            <!-- hidden -->
                                          </form>
                                        </div>


                                      </div>
                                    </div>



                                  </div>
                                  <div class="modal-footer submitBtnCenter">
                                    <button type="button" class="btn bg1btn"
                                      @click="step2PhotoUpload(item,index)">確認上傳</button>
                                    <button type="button" class="btn bg2btn" data-bs-dismiss="modal">取消</button>
                                  </div>
                                </div>
                              </div>
                            </div>
                            <!-- 照片上傳end -->
                          </tr>
                        </table>
                      </div>

                      <div class="submitBtnCenter flexContainer">
                        <button class="btn font-sm bg2btn" @click="toStep3()">下一步</button>
                      </div>


                    </div> <br>


                    <!-- step3 start -->
                    <div class="flexContainer step3" v-show="Step3show">
                      <p>Step.3</p>
                      <div class="font-sm flexContainer">
                        <div class="flexContainer">賣出後的收益轉為：</div>
                        <div class="flexContainer"><label><input type="radio" name="step3WithdrawType.WithdrawType"
                              v-model="step3WithdrawType.WithdrawType" value="ShoppingMoney"> 購書金
                          </label></div>
                        <div class="flexContainer"><label><input type="radio" name="step3WithdrawType.WithdrawType"
                              v-model="step3WithdrawType.WithdrawType" value="Remit"> 提領至銀行帳戶</label>
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
                          <input type="checkbox" class="checked-btn" id="read"> <label for="read">&nbsp;已閱讀
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
                    <!-- step3 end -->
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
  name: 'MemberUsedBookStep1View',
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
      Step1show: true,
      Step2show: false,
      Step3show: false,
      selectedFiles: [],
      
      // MenuList: []
    }
  },

  methods: {
    showStep2() {
      var self = this;
      if (self.step2UsedBookList.length > 0) {
        self.Step2show = true;
        return true
      } else {
        return false
      }
    },
    Step1BookSearch() {
      var self = this;
      var ISBN = document.querySelector("#ISBNInput").value;
      if (ISBN == "") {
        Swal.fire({
          title: "請輸入二手書的ISBN碼",
          icon: "info",
          timer: 1000,
          showConfirmButton: false,
        })
        return
      }
      $.ajax({
        method: "GET",
        dataType: 'JSON',
        url: `${GetApiUrl()}/member/Step1BookSearch/${ISBN}`,
      }).done(function (data) {
        console.log(data);
        var book = {
          MemberID: self.MemberID,
          ProductID: data.ID,
          ProductName: data.Name,
          SalePrice: "",
          ISBN10: data.ISBN10,
          ISBN13: data.ISBN13,
          WithdrawType: "",
          RemitAccount: "",
          BookStatus: "請選擇分級",
          VerifyStatus: 0,
          // VerifyDateTime: "",
          // Sold: "",
          Enable: true,
          photoUploaded:false,
        }
        self.step2UsedBookList.push(book);
        console.log(self.step2UsedBookList);
        document.querySelector("#ISBNInput").value = "";

        self.showStep2();
      });
    },
    DisplayImg: function (index, event) {
      var self = this;
      console.log(event);
      console.log($(event.target).siblings(".input-box-file-img").children("img")[0]);
      let files = event.target.files;
      if (files.length > 3) {
        Swal.fire({
          title: "最多只能上傳3張照片",
          icon: "info",
          timer: 2000,
          showConfirmButton: false,
        })
        event.target.value = null;
      }
      if (!files || files.length === 0) {
        return;
      }

      $(".photoInsert").prop("src", "");
      for (let i = 0; i < files.length; i++) {
        let file = files[i];
        if (file.type.startsWith('image/')) {
          $(event.target).siblings(".input-box-file-img").children(`.img${index}`).eq(i).prop("src", window.URL.createObjectURL(file));
        }

      }
      self.selectedFiles[index] = files;
      console.log(self.selectedFiles[index]);

    },
    step2PhotoUpload(item,index) {
      console.log(index);
      var self = this;
      console.log(self.selectedFiles[index]);
      var self = this;
      let files = self.selectedFiles[index];
      let btnID = "#insertPhotoBtn" + index;
      if (!files || files.length === 0) {
        Swal.fire({
          title: "請至少上傳1張書況照片",
          icon: "info",
          timer: 2000,
          showConfirmButton: false,
        })
      } else {

        // 待上傳改為編輯, bg1btn 改為 bg2btn
        document.querySelector(btnID).textContent = "編輯";
        document.querySelector(btnID).setAttribute("uploaded", "true");
        if (document.querySelector(btnID).getAttribute("uploaded") == "true") {
          document.querySelector(btnID).classList.remove("bg1btn");
          document.querySelector(btnID).classList.add("bg2btn");
        }
        item.photoUploaded = true;
        $("#insertPhoto" + index).modal('hide');
      }

    },

    toStep3() {
      var self = this;
      var swalshow = false;
      self.step2UsedBookList.forEach(item => {
        if (item.SalePrice == "" || item.BookStatus == "請選擇分級" || item.photoUploaded == false) {
          swalshow = true;
        }
      });

      if(swalshow){
        Swal.fire({
            title: "請將資料填寫完整",
            icon: "info",
            timer: 2000,
            showConfirmButton: false,
          })
      }else{
        console.log("show3");
        var self = this;
        // localStorage.setItem("step2UsedBookList", JSON.stringify(self.step2UsedBookList))
        self.Step1show = false;
        self.Step2show = false;
        self.Step3show = true;
        console.log(self.Step3show);
      }
      },
        
   



    // step3 //

    toStep2() {
      var self = this;
      // localStorage.setItem("step2UsedBookList", JSON.stringify(self.step2UsedBookList))
      // localStorage.setItem("step3WithdrawType", JSON.stringify(self.step3WithdrawType))
      // window.location.href = '/member/usedBookStep1'
      self.Step1show = true;
      self.Step2show = true;
      self.Step3show = false;

    },
    usedSalePolicy() {
      // const readElement = document.querySelector("#read");
      // if (readElement.hasAttribute("disabled")) {
      //   readElement.removeAttribute("disabled");
      // }
    },
    UsedSaleInsert() {
      var self = this;
      console.log("UsedSaleInsertOK");
      if (!document.querySelector("#read").checked) {
        Swal.fire({
          title: "請先閱讀二手書販賣須知",
          icon: "info",
          // text: "將於收件審核後上架",
          timer: 2000,
          showConfirmButton: false,
        });
      } else {
        console.log(self.step2UsedBookList);
        for (let j = 0; j < self.step2UsedBookList.length; j++) {

          console.log("test");
          let form = document.querySelector(`#form${j}`)
          if (form != null) {
            // $("input[name='__RequestVerificationToken']").val(Cookies.get('XSRF-TOKEN'));
            var data = new FormData(form);
            $.ajax({
              method: "POST",
              dataType: 'JSON',
              enctype: 'multipart/form-data',
              url: `${GetApiUrl()}/member/UsedSaleInsert`,
              data: data,
              cache: false,
              processData: false,
              contentType: false,
            }).done(function (data) {
              console.log(data);
              // currentBtn.removeClass('sending');
              Swal.fire({
                icon: data.result,
                title: data.title,
                text: data.text,
                timer: 2000,
                showConfirmButton: false,
                // text: "將於收件審核後上架",
              }).then(function () {
                if (data.result == "success") {
                  console.log(data);
                  window.location.href = "/member/usedBookStep3";
                } else {
                  console.log(data);
                }
              })
            }).fail(function (data) {
              // currentBtn.removeClass('sending');
              alert("發生錯誤");
            });

          }

        }

      }

    },


    // -----------------------------------------

    // SendForm: function (event) {
    //   let self = this;

    //   let currentBtn = $(event.target);
    //   if (currentBtn.hasClass('sending')) return;
    //   currentBtn.addClass('sending');

    //   $("input[name='__RequestVerificationToken']").val(Cookies.get('XSRF-TOKEN'));
    //   var data = new FormData($('#form')[0]);

    //   // let url;
    //   // if (self.$route.name === "backEdit") {
    //   //   url = `${GetApiUrl()}/Back/Edit${self.$route.params.modelName}ContentData/${self.$route.params.id}`;
    //   // } else {
    //   //   url = `${GetApiUrl()}/Back/Create${self.$route.params.modelName}ContentData`;
    //   // }

    //   $.ajax({
    //     method: "POST",
    //     dataType: 'JSON',
    //     enctype: 'multipart/form-data',
    //     url: `${GetApiUrl()}/Back/Create${self.$route.params.modelName}ContentData`;
    //     data: data,
    //     cache: false,
    //     processData: false,
    //     contentType: false,
    //   })
    //     .done(function (data) {
    //       currentBtn.removeClass('sending');

    //       Swal.fire({
    //         title: data.title,
    //         icon: data.result,
    //         timer: 2000,
    //         showConfirmButton: false,
    //       }).then(function () {
    //         if (data.result === "success") {
    //           if (self.$route.name === "backEdit") {
    //             document.location.reload();
    //           } else {
    //             document.location.href = `/back/edit/${self.$route.params.modelName}/${data.ID}`;
    //           }
    //         }
    //       });

    //       console.log(data);
    //     })
    //     .fail(function (data) {
    //       currentBtn.removeClass('sending');
    //       alert("發生錯誤");
    //     });
    // },
    // -----------------------------------------
  },



  async created() {
    var self = this;
    // localStorage
    // if (localStorage.getItem("step2UsedBookList") != null) {
    //   self.step2UsedBookList = JSON.parse(localStorage.getItem("step2UsedBookList"));
    // }

    // 會員中心選單
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
<style scoped src="../components/back/css/BackComponents.css"></style>