<template>
  <div class="col-md-12 col-lg-3">
    <div class="left-container-menu">
      <li class="category-toggle-title">
        選單
      </li>
      <ul class="category-link-wrap" :style="{display: categoryDisplay ? 'none' : 'flex'}">
        <li class="menu-title">
          <a :href="data.menuLink">{{ data.menuName }}</a>
        </li>
        <div class="menu-link">
          <template v-for="(item, index) in data.menuData">
            <li>
              <a :href="item.link" :class="{active:$route.path==item.link}">{{ item.title }}</a>
            </li>
            <hr>
          </template>
        </div>
      </ul>
    </div>
  </div>
</template>

<script>
export default {
  name: 'PageMenu',
  props: ["data"],
  data() {
    return {
      categoryDisplay: false,
    }
  },
  async mounted() {
    var self = this;

    // 取得網頁寬度
    self.categoryDisplay = window.innerWidth <= 991;

    // 響應式選單
    $(".category-toggle-title").on("click", function () {
      $(".category-link-wrap").toggle(300);
    });
  }
}
</script>

<style scoped>
.menu-link li a.active {
    border-radius: 5px;
    background-color: var(--bg-color1);
    color: white;
}
</style>