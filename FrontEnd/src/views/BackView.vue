<template>
  <div class="page">
    <backMenu></backMenu>
    <div class="content-wrap"></div>
  </div>
</template>

<script>
import backMenu from '@/components/back/BackMenu.vue'
export default {
  name: 'BackContentView',
  components: {
    backMenu,
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
</style>