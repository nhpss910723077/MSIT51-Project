<template>
  <TopBanner />
  <section>
    <BreadCrumb :data="breadCrumbData" />
  </section>
  <div class="container myContainner">
    <!-- 進度條 -->
    <div class="step row">
      <li class="col-12 col-md-4">Step 1 購物車</li>
      <li class="col-12 col-md-4 hov">Step 2 訂單資訊</li>
      <li class="col-12 col-md-4">Step 3 訂單完成</li>
    </div>
    <!-- 帳單資訊 -->
    <div class="row billing justify-content-center">
      <!-- 基本資料 -->
      <div class="col-12 col-md-5 leftform">
        <p>基本資料</p>
        <div>
          <label for="name">姓名 </label>
          <input id="name" v-model="OrderForm.ReceiveName" />
        </div>
        <div>
          <label for="email">Email </label>
          <input type="email" id="email" v-model="OrderForm.ReceiveEmail" />
        </div>
        <div>
          <label for="phone">電話 </label>
          <input id="phone" v-model="OrderForm.ReceivePhone" />
        </div>
        <div id="twzipcode" v-show="MyShow1()">
          <label>縣市</label>
          <div
            id="County"
            data-role="county"
            data-style="form-select"
            ref="countyElement"
          ></div>
          <label>鄉鎮市區</label>
          <div
            id="District"
            data-role="district"
            data-style="form-select"
            ref="districtElement"
          ></div>
          <label>郵遞區號</label>
          <div id="Zipcode" data-role="zipcode" ref="zipcodeElement"></div>
        </div>
        <div v-show="MyShow1()">
          <label for="address">地址 </label>
          <input id="address" v-model="OrderForm.ReceiveAddress" />
        </div>
        <div>
          <label for="Remark">訂單備註 </label>
          <textarea name="" id="Remark" v-model="OrderForm.Remark"></textarea>
        </div>
      </div>
      <!-- 確認訂單 -->
      <hr class="divider2" />
      <div class="col-12 col-md-6 rightform">
        <p>確認訂單</p>
        <table>
          <thead>
            <tr>
              <th>商品</th>
              <th>價格</th>
            </tr>
          </thead>
          <tbody>
            <!-- 商品 -->
            <tr v-for="Product in Products">
              <td>
                <div
                  class="ellipsis"
                  :title="Product.Name + ' * ' + Product.Quantity"
                >
                  {{ Product.Name }} * {{ Product.Quantity }}
                </div>
              </td>
              <td>NT${{ Product.SalePrice * Product.Quantity }}</td>
            </tr>
          </tbody>
          <tfoot>
            <!-- 小計 -->
            <tr>
              <th>小計</th>
              <td>NT${{ MySubTotal() }}</td>
            </tr>
            <!-- 配送方式 -->
            <tr>
              <th>配送方式</th>
              <td>
                <li>
                  <input
                    id="shipping1"
                    type="radio"
                    v-model="OrderForm.ShippingType"
                    value="1"
                  /><label for="shipping1">宅配</label>
                </li>
                <li>
                  <input
                    id="shipping2"
                    type="radio"
                    v-model="OrderForm.ShippingType"
                    value="2"
                  /><label for="shipping2">超商</label>
                  <div v-show="MyShow2()">
                    <select v-model="B2C">
                      <option>萊爾富</option>
                      <option>全家</option>
                      <option>統一超商</option>
                    </select>
                    <button class="mybtn" @click="GetMap()">電子地圖</button>
                  </div>
                </li>
              </td>
            </tr>
            <!-- 付款方式 -->
            <tr>
              <th>付款方式</th>
              <td>
                <li>
                  <input
                    id="pay1"
                    type="radio"
                    value="1"
                    v-model="OrderForm.PaymentType"
                  /><label for="pay1">信用卡</label>
                </li>
                <li>
                  <input
                    id="pay2"
                    type="radio"
                    value="2"
                    v-model="OrderForm.PaymentType"
                  /><label for="pay2">ATM</label>
                </li>
                <li>
                  <input
                    id="pay3"
                    type="radio"
                    value="3"
                    v-model="OrderForm.PaymentType"
                  /><label for="pay3">超商代碼</label>
                </li>
                <li>
                  <input
                    id="pay4"
                    type="radio"
                    value="4"
                    v-model="OrderForm.PaymentType"
                  /><label for="pay4">超商條碼</label>
                </li>
                <li class="leftform">
                  <label for="ShoppingMoney" style="padding: 0px"
                    >現有購物金 : NT${{
                      ShoppingMoney - UseShoppingMoney
                    }}</label
                  >
                  <input
                    id="ShoppingMoney"
                    type="input"
                    v-model="UseShoppingMoney"
                    style="height: 40px; width: 200px"
                    placeholder="折抵最多20%"
                    @change="UseMoney()"
                  />
                </li>
              </td>
            </tr>
            <!-- 運費 -->
            <tr>
              <th>運費</th>
              <td>NT${{ MyFee() }}</td>
            </tr>
            <!-- 總計 -->
            <tr>
              <th>總計</th>
              <td>NT${{ MyTotal() }}</td>
            </tr>
          </tfoot>
        </table>
      </div>
    </div>

    <!-- 按鈕 -->
    <div class="profooter row justify-content-center">
      <div class="col-6 col-md-5">
        <a href="./Step1"><button class="mybtn mybtnnext">上一步</button></a>
      </div>
      <div class="col-6 col-md-6 text-end">
        <button class="mybtn mybtnnext" @click="AddOrderForm()">
          送出訂單
        </button>
        <button
          style="display: none"
          id="test"
          class="mybtn mybtnnext"
          @click="AddCVSShipping()"
        >
          TEST
        </button>
      </div>
    </div>
    <!-- 給綠界CVS物流訂單的參數 -->
    <form
      method="post"
      action="https://logistics-stage.ecpay.com.tw/Express/Create"
      id="CVSShipping"
    >
      <div v-for="(x, index) in CVSShipping" v-bind:key="x">
        <input type="hidden" :name="index" v-model="CVSShipping[index]" />
      </div>
      <button style="display: none">送出</button>
    </form>
    <!-- 給綠界電子地圖的參數 -->
    <form
      method="post"
      action="https://logistics-stage.ecpay.com.tw/Express/map"
      id="map"
    >
      <div v-for="(x, index) in AddMap" v-bind:key="x">
        <input type="hidden" :name="index" v-model="AddMap[index]" />
      </div>
      <button style="display: none">送出</button>
    </form>
    <!-- 給綠界金流的參數 -->
    <form
      method="post"
      action="https://payment-stage.ecpay.com.tw/Cashier/AioCheckOut/V5"
    >
      <div v-for="(x, index) in EcpayOrders" v-bind:key="x">
        <input type="hidden" :name="index" v-model="EcpayOrders[index]" />
      </div>
      <button id="payment" style="display: none">送出</button>
    </form>
  </div>
</template>

<script>
import TopBanner from "@/components/shared/TopBanner.vue";
import BreadCrumb from "@/components/shared/BreadCrumb.vue";
var lastClickTime = 0;

export default {
  name: "CartStep2View",
  data() {
    return {
      breadCrumbData: [
        { title: "首頁", link: "/" },
        { title: "購物車", link: "" },
      ],
      OrderForm: {
        MemberID: parseInt(sessionStorage.getItem("MemberID"), 10),
        Number: "0",
        ReceiveName: "",
        ReceiveEmail: "",
        ReceivePhone: "",
        ReceiveCounty: "",
        ReceiveDistrict: "",
        ReceiveZipcode: "",
        ReceiveAddress: "",
        Remark: "",
        SubTotal: 0,
        ShippingType: 1,
        PaymentType: 1,
        ShippingFee: 60,
        Total: 0,
      },
      Products: [],
      EcpayOrders: {
        MerchantTradeNo: "",
        MerchantTradeDate: "",
        TotalAmount: "",
        TradeDesc: "",
        ItemName: "",
        ReturnURL: "",
        MerchantID: "",
        PaymentType: "",
        ChoosePayment: "",
        EncryptType: "",
        CheckMacValue: "",
      },
      AddMap: {
        MerchantID: "",
        MerchantTradeNo: "",
        LogisticsType: "",
        LogisticsSubType: "",
        IsCollection: "",
        ServerReplyURL: "",
      },
      CVSShipping: {
        MerchantID: "",
        MerchantTradeDate: "",
        LogisticsType: "",
        GoodsAmount: "",
        SenderName: "",
        ReceiverName: "",
        ReceiverCellPhone: "",
        ServerReplyURL: "",
        LogisticsSubType: "",
        ReceiverStoreID: "",
        CheckMacValue: "",
      },
      B2C: "萊爾富",
      MemberID: parseInt(sessionStorage.getItem("MemberID"), 10),
      ShoppingMoney: 0,
      UseShoppingMoney: null,
    };
  },
  methods: {
    UseMoney() {
      var max = Math.round(
        (this.OrderForm.SubTotal + this.OrderForm.ShippingFee) * 0.2
      );
      var min = 0;
      if (this.ShoppingMoney >= max) {
        if (this.UseShoppingMoney > max) {
          return (this.UseShoppingMoney = max);
        }
      } else {
        if (this.UseShoppingMoney > this.ShoppingMoney) {
          return (this.UseShoppingMoney = this.ShoppingMoney);
        }
      }
      if (parseInt(this.UseShoppingMoney) < min) {
        return (this.UseShoppingMoney = 0);
      }
      this.UseShoppingMoney = this.UseShoppingMoney.replace(/[^0-9]/g, "");
    },
    MySubTotal() {
      var _SubTotal = 0;
      this.Products.forEach((item) => {
        _SubTotal += item.SalePrice * item.Quantity;
      });
      return (this.OrderForm.SubTotal = _SubTotal);
    },
    MyFee() {
      return (this.OrderForm.ShippingFee =
        this.OrderForm.SubTotal > 700 ? 0 : 60);
    },
    MyTotal() {
      if (this.UseShoppingMoney != null) {
        return (this.OrderForm.Total =
          this.OrderForm.SubTotal +
          this.OrderForm.ShippingFee -
          this.UseShoppingMoney);
      } else {
        return (this.OrderForm.Total =
          this.OrderForm.SubTotal + this.OrderForm.ShippingFee);
      }
    },
    MyShow1() {
      return this.OrderForm.ShippingType == 1;
    },
    MyShow2() {
      return this.OrderForm.ShippingType == 2;
    },
    TWzipcodeInputChange(event) {
      // 取得所有三個元素的當前值
      const countyValue = this.$refs.countyElement.children[0].value;
      const districtValue = this.$refs.districtElement.children[0].value;
      const zipcodeValue = this.$refs.zipcodeElement.children[0].value;

      // 更新Vue實例的數據屬性
      this.OrderForm.ReceiveCounty = countyValue;
      this.OrderForm.ReceiveDistrict = districtValue;
      this.OrderForm.ReceiveZipcode = zipcodeValue;
    },
    // 新增訂單
    async AddOrderForm() {
      var self = this;
      var cooldownTime = 5000;
      var currentTime = new Date().getTime();
      if (currentTime - lastClickTime >= cooldownTime) {
        await $.ajax({
          method: "POST",
          dataType: "JSON",
          url: `${GetApiUrl()}/Cart/AddOrderForm`,
          data: this.OrderForm,
        })
          .done(function (data) {
            console.log(data);
            // 加入訂單明細
            self.Products.forEach(async (x) => {
              var addData = {
                OrderFormID: 0,
                ProductID: x.ProductID,
                ProductName: x.Name,
                Quantity: x.Quantity,
                SalePrice: x.SalePrice,
                MemberID: self.MemberID,
                Type: x.Type,
                UsedID: x.UsedID,
              };
              await $.ajax({
                method: "POST",
                dataType: "JSON",
                url: `${GetApiUrl()}/Cart/AddOrderDetail`,
                data: addData,
              })
                .done(function (data) {
                  console.log(data);
                })
                .fail(function (data) {
                  console.log(data);
                });
            });

            // 發送金流訂單到綠界
            setTimeout(() => {
              $.ajax({
                method: "POST",
                url: `${GetApiUrl()}/Cart/AddEcpayOrders`,
                data: {
                  PaymentType: self.OrderForm.PaymentType,
                  ShippingType: self.OrderForm.ShippingType,
                  MemberID: self.MemberID,
                  UseShoppingMoney: self.UseShoppingMoney,
                },
              })
                .done(function (data) {
                  console.log(data);
                  self.EcpayOrders = data;
                  setTimeout(() => {
                    $("#payment").click();
                  }, 1000);
                })
                .fail(function (data) {
                  console.log(data);
                });
            }, 1000);
          })
          .fail(function (data) {
            console.log(data);
          });
        lastClickTime = currentTime;
      }
    },
    // 發送電子地圖請求
    GetMap() {
      var self = this;
      $.ajax({
        method: "POST",
        url: `${GetApiUrl()}/Cart/AddMap`,
        data: { LogisticsSubType: self.B2C },
      })
        .done(function (data) {
          console.log(data);
          self.AddMap = data;
          setTimeout(() => {
            $("#map").submit();
          }, 1000);
        })
        .fail(function (data) {
          console.log(data);
        });
    },
    // 發送物流訂單到綠界  做完發現用不到
    AddCVSShipping() {
      var self = this;
      $.ajax({
        method: "POST",
        url: `${GetApiUrl()}/Cart/AddCVSShipping`,
        data: {
          LogisticsSubType: self.B2C,
          Total: self.OrderForm.Total,
          ReceiveName: self.OrderForm.ReceiveName,
          ReceivePhone: self.OrderForm.ReceivePhone,
        },
      })
        .done(function (data) {
          console.log(data);
          self.CVSShipping = data;
          setTimeout(() => {
            $("#CVSShipping").submit();
          }, 1000);
        })
        .fail(function (data) {
          console.log(data);
        });
    },
  },
  async created() {
    var self = this;

    // 獲取會員資料
    try {
      await $.ajax({
        method: "GET",
        dataType: "JSON",
        url: `${GetApiUrl()}/Cart/Member`,
        data: { MemberID: self.MemberID },
      })
        .done(function (data) {
          self.OrderForm.ReceiveName = data[0].Name;
          self.OrderForm.ReceiveEmail = data[0].Account;
          self.OrderForm.ReceivePhone = data[0].Phone;
          self.OrderForm.ReceiveCounty = data[0].County;
          self.OrderForm.ReceiveDistrict = data[0].District;
          self.OrderForm.ReceiveZipcode = data[0].Zipcode;
          self.OrderForm.ReceiveAddress = data[0].Address;
          self.ShoppingMoney = data[0].ShoppingMoney;
          // TWZipcode套件
          $("#twzipcode").twzipcode({
            readonly: true,
            countySel: self.OrderForm.ReceiveCounty,
            districtSel: self.OrderForm.ReceiveDistrict,
            zipcodeSel: self.OrderForm.ReceiveZipcode,
          });
        })
        .fail(function (data) {
          console.log("發生錯誤");
        });
    } catch (error) {
      console.log("發生錯誤");
    }

    // 獲取購物車資料
    try {
      // 獲取購物車資料_Normal
      await $.ajax({
        method: "GET",
        dataType: "JSON",
        url: `${GetApiUrl()}/Cart/CartNormal`,
        data: { MemberID: self.MemberID },
      })
        .done(function (data) {
          self.Products = data;
        })
        .fail(function (data) {
          alert("發生錯誤");
        });
      // 獲取購物車資料_Customer
      $.ajax({
        method: "GET",
        dataType: "JSON",
        url: `${GetApiUrl()}/Cart/CartCustomer`,
        data: { MemberID: self.MemberID },
      })
        .done(function (data) {
          // 將Normal跟Customer合併成一個陣列
          self.Products = self.Products.concat(data);
        })
        .fail(function (data) {
          alert("發生錯誤");
        });
    } catch (error) {
      console.log("發生錯誤");
    }

    // TWZipcode套件事件綁定
    this.$refs.countyElement.addEventListener(
      "change",
      this.TWzipcodeInputChange
    );
    this.$refs.districtElement.addEventListener(
      "change",
      this.TWzipcodeInputChange
    );
    this.$refs.zipcodeElement.addEventListener(
      "change",
      this.TWzipcodeInputChange
    );
  },
  components: {
    TopBanner,
    BreadCrumb,
  },
};
</script>

<!-- <style scoped src="./css/Cart.css"></style> -->
<style src="./css/Cart.css"></style>
