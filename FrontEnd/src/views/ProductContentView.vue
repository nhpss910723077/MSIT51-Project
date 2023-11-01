<template>
  <TopBanner />
  <section>
    <BreadCrumb :data="breadCrumbData" />
  </section>
  <ProductContentData :productData="productData" />
  <ProductSuggest />
</template>

<script>
import TopBanner from '@/components/shared/TopBanner.vue'
import BreadCrumb from '@/components/shared/BreadCrumb.vue'
import ProductContentData from '@/components/product/ProductContentData.vue'
import ProductSuggest from '@/components/product/ProductSuggest.vue'

export default {
  name: 'ProductContentView',
  data() {
    return {
      breadCrumbData: [
        { title: "首頁", link: "/" },
        { title: "館藏分類", link: "/product/lists" },
        { title: "", link: "" },
        { title: "", link: "" },
      ],
      productData: [],
    }
  },
  async created() {
    var self = this;
    var id = self.$route.params.id;

    try {
      await $.ajax({
        method: "GET",
        dataType: "JSON",
        url: `${GetApiUrl()}/Product/GetProductInProduct/${id}`,
      })
        .done(function (data) {
          self.productData.Name = data.Name;
          self.productData.pID = data.pID;
          self.productData.Img1 = data.Img1;
          self.productData.Author = data.Author;
          self.productData.Translator = data.Translator;
          self.productData.Publisher = data.Publisher;
          self.productData.PublishDate = data.PublishDate.split('T')[0];
          self.productData.ListPrice = data.ListPrice;
          self.productData.SalePrice = data.SalePrice;
          self.productData.Content = data.Content;
          self.productData.AuthorContent = data.AuthorContent;
          self.productData.Specification = data.Specification;
          self.productData.CategoryName = data.CategoryName;
          self.productData.ISBN13 = data.ISBN13;
          self.breadCrumbData[2].title = data.CategoryName;
          self.breadCrumbData[2].link = `/product/lists/${data.ProductCategoryID}`;
          self.breadCrumbData[3].title = data.Name;
        })
    } catch (error) {
      console.log("發生錯誤");
    }
  },
  components: {
    TopBanner,
    BreadCrumb,
    ProductContentData,
    ProductSuggest
  },
}
</script>