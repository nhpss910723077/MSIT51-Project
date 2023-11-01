<template>
  <div class="col-12" :class="`col-lg-${field['ColSize']}`">
    <div class="form-group input-box">
      <label class="control-label">{{ field['Name'] }}</label>
      <table class="table list-wrap order-detail-table">
        <thead class="table-dark">
          <tr>
            <th width="100px">編號</th>
            <th width="100px">產品圖片</th>
            <th>產品名稱</th>
            <th width="100px">單價</th>
            <th width="100px">數量</th>
            <th width="100px">小計</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(item, index) in content['OrderDetail']">
            <th>{{ index + 1 }}</th>
            <th><img :src="item.ProductImg"></th>
            <th>{{item.ProductName}}</th>
            <th>{{item.SalePrice}}</th>
            <th>{{item.Quantity}}</th>
            <th>{{item.SalePrice * item.Quantity}}</th>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="col-12" v-if="field['CutCol']"></div>
</template>

<script>
export default {
  name: 'BackOrderDetail',
  props: ["index", "field", "content"]
}
</script>

<style scoped src="./css/BackComponents.css"></style>