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
          <div class="memberContent">
            <!-- URL -->
            <div class="Content">

              <div class="title">訂單查詢</div>


              <hr style="border: 0;">
              <!-- <div v-if="orderList && orderList.length > 0"> -->
                <div class="accordion order" v-for="(item, index) in orderList">
                  <div class="accordion-item">
                    <h2 class="accordion-header " :id="'AH-' + item.ID">
                      <button class="accordion-button" :class="index === 0 ? '' : 'collapsed'" type="button"
                        data-bs-toggle=collapse :data-bs-target="'#collapse-' + item.ID"
                        :aria-expanded="index === 0 ? 'true' : 'false'" :aria-controls="'collapse-' + item.ID">

                        <!-- <div style="flex: wrap ; "> -->
                        <div class="acd-h-L font-bold">
                          訂單日期 | {{ item.CreateTime.split("T")[0] }}
                        </div>
                        <div class="acd-h-C font-bold">
                          訂單金額 | ${{ item.Total }}
                        </div>
                        <div class="acd-h-R font-bold">
                          {{ item.Status }}
                        </div>
                        <!-- </div> -->
                      </button>
                    </h2>
                    <div :id="'collapse-' + item.ID" class="accordion-collapse" :class="index === 0 ? 'show' : 'collapse'"
                      aria-labelledby="headingOne">
                      <div class="accordion-body flexContainer">
                        <div class="orderProduct">
                          <table class="productList flexContainer">
                            <tr class="flexContainer">
                              <th colspan="1">商品清單</th>
                              <th colspan="4"></th>
                            </tr>
                            <tr class="flexContainer" v-for="product in item.OrderDetail">
                              <td><img :src="product.Img1" :alt="product.ProductName"></td>
                              <td colspan="2">
                                <div v-if="returnLabel(product, item)" class="returnProduct">已退貨</div>
                                <!-- <div v-if="product.ProductID == 2 || product.ProductID == 3" class="returnProduct">hello</div> -->
                                <div class="txtshort" :title="product.ProductName">{{ product.ProductName }}</div>
                              </td>
                              <td>x{{ product.Quantity }}</td>
                              <td>${{ product.SalePrice }}</td>
                            </tr>
                          </table>
                        </div>
                        <div class="orderDetail">
                          <table class="DetailList flexContainer">
                            <tr class="flexContainer">
                              <th>訂單資訊</th>
                            </tr>
                            <tr class="flexContainer">
                              <td class="flexContainer">
                                <span>訂單編號</span>
                                |
                                <span class="txtshort" :title="item.Number">{{ item.Number }}</span>
                              </td>
                              <td class="flexContainer">
                                <span>配送方式</span>
                                |
                                <span>{{ item.ShippingType }}</span>
                              </td>
                              <td v-show="item.CVSStoreName == null ? false : true" class="flexContainer">
                                <span>取貨門市</span>
                                |
                                <span>{{ item.CVSStoreName }}</span>
                              </td>
                              <!-- <td style="display: flex;padding-left: 15px;">
                              <span style="flex: 4;">優惠券</span> 
                              <span
                                style="flex: 1;">|</span>
                              <span style="flex: 5;">$0</span>
                            </td> -->
                              <td class="flexContainer">
                                <span>運費</span>
                                |
                                <span>${{ item.ShippingFee }}</span>
                              </td>
                              <td class="flexContainer">
                                <span>付款方式</span>
                                |
                                <span>{{ item.PaymentName }}</span>
                              </td>
                              <td class="flexContainer">
                                <span>訂單總金額</span>
                                |
                                <span>${{ item.Total }}</span>
                              </td>


                              <th class="orderProcess" v-show="item.Status == '訂單完成' ? true : false"><button
                                  class="btn bg2btn" data-bs-toggle="modal"
                                  :data-bs-target="'#return-' + item.ID">申請退貨</button>

                                <div class="modal fade" :id="'return-' + item.ID" data-bs-backdrop="true"
                                  data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel"
                                  aria-hidden="true">
                                  <div class="modal-dialog modal-lg modal-dialog-centered">
                                    <div class="modal-content">
                                      <div class="modal-header">
                                        <h5 class="modal-title font-sm font-bold" style="padding: 10px;"
                                          id="staticBackdropLabel">
                                          退貨申請：{{ item.Number }}</h5>
                                        <button type="button" class="btn-close" data-bs-dismiss="modal"
                                          aria-label="Close"></button>
                                      </div>
                                      <div class="modal-body">

                                        <table class="returnList flexContainer">
                                          <tr class="flexContainer">
                                            <th>退貨</th>
                                            <th>商品清單</th>
                                            <th colspan="2">商品名稱</th>
                                            <th>數量</th>

                                          </tr>
                                          <tr class="flexContainer" v-for="product in item.OrderDetail">
                                            <td class="flexContainer">
                                              <!-- <div><label :for="'#returnRadio' + item.ID">
                                                <input type="radio" name="returnOrChange" :id="'#returnRadio' + item.ID">
                                              </label></div>
                                            <div><label :for="'#changeRadio' + item.ID">
                                                <input type="radio" name="returnOrChange" :id="'#changeRadio' + item.ID">
                                              </label></div> -->
                                              <input type="checkbox" :id="'return' + product.ProductID"
                                                :value=product.ProductID v-model="ReturnIDs" @change="RetrunIDList()">
                                            </td>
                                            <td class="flexContainer"><label :for="'return' + product.ProductID"><img
                                                  :src="product.Img1" :alt="product.ProductName"></label></td>
                                            <td colspan="2" class="flexContainer">
                                              <label :for="'return' + product.ProductID" class="txtshort"
                                                :title="product.ProductName">{{ product.ProductName }}</label>
                                            </td>
                                            <td class="flexContainer"><label :for="'return' + product.ProductID">{{
                                              product.Quantity }}</label></td>

                                          </tr>
                                        </table>
                                        <hr>
                                        <div class="flexContainer">
                                          <div class="centerDiv">*提醒您：單筆訂單僅能申請退貨一次</div>
                                          <div class="centerDiv">
                                            <label :for="'returnReason' + item.ID"> 取消原因：</label>
                                            <select class="returnReason" name="returnReason"
                                              :id="'returnReason' + item.ID" v-model="selectedRetrunReason">
                                              <option disabled>請選擇</option>
                                              <option v-for="reason in RetrunReason" :value="reason">{{ reason }}</option>
                                            </select>
                                          </div>
                                        </div>
                                      </div>
                                      <div class="modal-footer">
                                        <!-- 送資料到資料庫-EDIT -->
                                        <button type="button" class="btn bg1btn" @click="orderReturn(item)">儲存</button>
                                        <button type="button" class="btn bg2btn" data-bs-dismiss="modal">取消</button>
                                      </div>
                                    </div>

                                  </div>

                                </div>


                              </th>
                              <th class="orderProcess" v-show="item.Status == '訂單成立' ? true : false">
                                <button class="btn bg2btn" data-bs-toggle="modal"
                                  :data-bs-target="'#cancel-' + item.ID">取消訂單</button>
                                <div class="modal fade" :id="'cancel-' + item.ID" data-bs-backdrop="true"
                                  data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel"
                                  aria-hidden="true">
                                  <div class="modal-dialog modal-lg modal-dialog-centered">
                                    <div class="modal-content">
                                      <div class="modal-header">
                                        <h5 class="modal-title font-sm font-bold" style="padding: 10px;">
                                          取消訂單：{{ item.Number }}</h5>
                                        <button type="button" class="btn-close" data-bs-dismiss="modal"
                                          aria-label="Close"></button>
                                      </div>
                                      <div class="modal-body">
                                        <table class="flexContainer productList cancelProductList">
                                          <tr class="flexContainer font-bold">
                                            <td>商品清單</td>
                                            <td colspan="2">商品名稱</td>
                                            <td>數量</td>
                                            <td>售價</td>

                                          </tr>
                                          <tr class="flexContainer" v-for="product in item.OrderDetail">
                                            <td><img :src="product.Img1" :alt="product.ProductName"></td>
                                            <td colspan="2" class="txtshort" :title="product.ProductName">{{
                                              product.ProductName }}</td>
                                            <td>x{{ product.Quantity }}</td>
                                            <td>${{ product.SalePrice }}</td>
                                          </tr>
                                        </table>
                                        <hr>
                                        <div class="flexContainer">
                                          <div class="cancelReason">
                                            <label :for="'cancelReason' + item.ID"> 取消原因：</label>
                                            <select :name="'cancelReason' + item.ID" :id="'cancelReason' + item.ID"
                                              v-model="selectedCancelReason">
                                              <option v-for="reason in cancelReason" :value="reason">{{ reason }}</option>
                                            </select>
                                          </div>
                                        </div>

                                      </div>
                                      <div class="modal-footer">
                                        <!-- 送資料到資料庫-EDIT -->
                                        <button type="button" class="btn bg1btn"
                                          @click="orderCancel(item, reason)">儲存</button>
                                        <button type="button" class="btn bg2btn" data-bs-dismiss="modal">取消</button>
                                      </div>
                                    </div>

                                  </div>

                                </div>
                              </th>
                              <th class="orderProcess"
                                v-show="item.Status == '訂單取消' || item.Status == '訂單退貨' ? true : false">
                                <button class="btn bg2btn">再次訂購</button>
                              </th>
                            </tr>
                          </table>

                        </div>
                      </div>
                    </div>
                  </div>
                  <hr>
                </div>
              <!-- </div> -->
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
  name: 'MemberOrderView',
  data() {
    return {
      MemberID: parseInt(sessionStorage.getItem('MemberID')),
      breadCrumbData: [
        { title: "首頁", link: "/" },
        { title: "會員中心", link: "/member/index" },
        { title: "訂單查詢", link: "" },
      ],
      PageMenuData: {
        menuName: "會員中心",
        menuLink: "/member/index",
        menuData: []
      },
      orderList: [],
      orderReturnList: [],
      // MenuList: [],  
      ReturnIDs: [],
      RetrunReason: ["商品有瑕疵或毀損", "商品數量有誤", "其他"],
      selectedRetrunReason: "請選擇",

      cancelReason: ["變更購買項目", "送貨或付款資訊填寫錯誤", "其他原因"],
      selectedCancelReason: "",
    }
  },
  methods: {

    // addClass:
    //   function (href) {
    //     var f = href.split("./");
    //     console.log(window.location.href);
    //     console.log(f[f.length - 1]);
    //     console.log(window.location.href.indexOf(f[f.length - 1]));

    //     if (window.location.href.indexOf(f[f.length - 1]) > 0) {
    //       return true;
    //     } else {
    //       return false;
    //     }
    //     // return false;
    //   },
    returnLabel(product, item) {
      var self = this;
      for (let i = 0; i < self.orderReturnList.length; i++) {
        var list = self.orderReturnList[i];
        var returnProduct = myParseJSON(list.ReturnProduct);

        if (item.ID == list.ID) {
          /*
          if(returnProduct.includes(product.ProductID)){
            return true;
          }else{
            return false;
          }*/

          for (let j = 0; j < returnProduct.length; j++) {
            if (product.ProductID == returnProduct[j]) {
              return true;
            }
          }
          return false;
        }
      }
    },
    RetrunIDList() {
      console.log(this.ReturnIDs);
    },
    orderReturn(item) {
      var self = this;
      console.log(self.selectedRetrunReason);
      console.log("rtest");
      console.log(self.ReturnIDs);
      $.ajax({
        method: "POST",
        dataType: 'JSON',
        url: `${GetApiUrl()}/member/orderReturn`,
        data: {
          OrderFormID: item.ID,
          ReturnProduct: JSON.stringify(self.ReturnIDs),
          Reason: self.selectedRetrunReason,
        }
      }).done(function (data) {
        console.log(data);
        Swal.fire({

          title: data.title,
          icon: data.result,
          timer: 2000,
          showConfirmButton: false,

        });
        setTimeout(function () {
          window.location.href = window.location.href
        }, 2000);

      });
    },
    orderCancel(item) {
      var self = this;
      console.log(self.selectedCancelReason);
      $.ajax({
        method: "POST",
        dataType: 'JSON',
        url: `${GetApiUrl()}/member/orderCancel`,
        data: {
          OrderFormID: item.ID,
          Reason: self.selectedCancelReason,

        }
      }).done(function (data) {
        Swal.fire({

          title: data.title,
          icon: data.result,
          timer: 2000,
          showConfirmButton: false,

        });
        setTimeout(function () {
          window.location.href = window.location.href
        }, 2000);

      });
    }
  },
  async created() {

    var self = this;
    try {
      $.ajax({
        method: "GET",
        dataType: 'JSON',
        url: `${GetApiUrl()}/member/orderList/${self.MemberID}`,
      }).done(function (data) {
        // data.orderReturnList.ReturnProduct = JSON.parse(data.orderReturnList.ReturnProduct);
        self.orderReturnList = data.orderReturnList;
        self.orderList = data.orderList;
        // console.log(myParseJSON(self.orderReturnList[0].ReturnProduct))

      });
    } catch (error) {
      console.log("發生錯誤");
    }
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