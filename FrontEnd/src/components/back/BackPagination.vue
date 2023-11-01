<template>
  <div class="back-pagination-wrap">
    <nav v-if="totalPage > 1">
      <ul class="pagination">
        <li class="page-item" v-if="page != 1">
          <router-link :to="`${link}?page=${page - 1}`" class="page-link">&lt;</router-link>
        </li>
        <template v-for="n in endPage">
          <template v-if="page == (n + startPage - 1)">
            <li class="page-item active">
              <span class="page-link">
                {{ n + startPage - 1 }}
                <span class="sr-only">(current)</span>
              </span>
            </li>
          </template>
          <template v-else>
            <li class="page-item">
              <router-link :to="`${link}?page=${n + startPage - 1}`" class="page-link">{{ n + startPage -
                1 }}</router-link>
            </li>
          </template>
        </template>
        <li class="page-item" v-if="totalPage != page && totalPage != 0">
          <router-link :to="`${link}?page=${page + 1}`" class="page-link">&gt;</router-link>
        </li>
      </ul>
    </nav>
  </div>
</template>

<script>
export default {
  name: 'BackPagination',
  data() {
    return {
      totalRow: 0,
      pageNumber: 5,
      pageSize: 20,
    }
  },
  watch: {
    '$route'(to, from) {
      this.GetPage();
    }
  },
  computed: {
    page: function () {
      return this.$route.query.page ? parseInt(this.$route.query.page) : 1;
    },
    link: function () {
      return `/back/lists/${this.$route.params.modelName}`;
    },
    totalPage: function () {
      return Math.ceil(this.totalRow / this.pageSize);
    },
    startPage: function () {
      if (this.page > this.pageNumber + 1) {
        return this.page - this.pageNumber;
      } else {
        return 1;
      }
    },
    endPage: function () {
      var result;
      if (this.page > this.pageNumber + 1) {
        result = (this.totalPage > (this.page + this.pageNumber)) ? this.page + this.pageNumber : this.totalPage;
      } else {
        result = (this.totalPage < this.pageNumber * 2) ? this.totalPage : this.pageNumber * 2;
      }
      result = result - this.startPage + 1;

      return result;
    },
  },
  methods: {
    GetPage: async function () {
      let self = this;
      
      // 取得分頁資料
      try {
        await $.ajax({
          method: "get",
          url: `${GetApiUrl()}/Back/Get${self.$route.params.modelName}PaginationData${location.search}`,
        })
          .done(function (data) {
            self.totalRow = data.totalRow;
            self.pageSize = data.pageSize;
          })
          .fail(function (data) {
            console.log("無法取得資料");
          });
      } catch (error) {
        console.log("發生錯誤");
      }
    }
  },
  async created() {
    this.GetPage();
  }
}
</script>

<style scoped>
.back-pagination-wrap {
  display: flex;
  justify-content: center;
  margin-top: 25px;
}
</style>