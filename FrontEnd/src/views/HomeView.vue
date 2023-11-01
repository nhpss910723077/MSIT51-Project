<template>
  <TopSlide />

  <div id="animateBird" class="animate-bird">
    <img :src="`/images/bird.png`" alt="">
  </div>
  <img class="home-bg-light" :src="`/images/light-bg.jpg`" alt="">

  <NewBookSlide />

  <div class="justify-content-center">
    <hr class="divider-line ">
  </div>
  <img class="home-bg-tree" :src="`/images/tree-bg.jpg`" alt="">

  <section>
    <div class="container">
      <div class="row">
        <SuggestBook />
        <div class="col-md-12 col-lg-8">
          <UsedBookSlide />
        </div>
      </div>
    </div>
  </section>

  <NewsSlide />
 
</template>

<script>
// @ is an alias to /src
import TopSlide from '@/components/home/TopSlide.vue'
import NewBookSlide from '@/components/home/NewBookSlide.vue'
import SuggestBook from '@/components/home/SuggestBook.vue'
import UsedBookSlide from '@/components/home/UsedBookSlide.vue'
import NewsSlide from '@/components/home/NewsSlide.vue'

export default {
  name: 'HomeView',
  components: {
    TopSlide,
    NewBookSlide,
    SuggestBook,
    UsedBookSlide,
    NewsSlide
  },
 

}
</script>

<style scoped src="./css/Home.css"></style>
