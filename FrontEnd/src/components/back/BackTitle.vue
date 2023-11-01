<template>
  <div class="col-12">
    <div class="content-title">
      {{ title }} - {{ type }}
    </div>
  </div>
</template>

<script>
export default {
  name: 'BackTitle',
  props: ["title"],
  computed: {
    type: function (tagName) {
      if (this.$route.name === "backEdit") {
        return "修改";
      } else if (this.$route.name === "backCreate") {
        return "新增";
      } else { 
        return "列表";
      }
    },
  },
}
</script>

<style scoped>
.content-title {
  font-size: 30px;
  font-weight: bold;
  padding-bottom: 25px;
}
</style>