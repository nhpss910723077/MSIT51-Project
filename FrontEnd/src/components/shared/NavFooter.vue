<template>
  <div id="btnTop">
    <a id="scrollButton" class="btn-top hidden" href="#">
      <span @onclick="scrollToTop()">Top</span>
    </a>
  </div>

  <div class="bg-dark text-center text-white">
    <div class="container footer">
      <div class="bg-dark">
        <a class="btn btn-outline-light btn-floating m-1" href="https://www.facebook.com/" role="button"><i
            class="fab fa-facebook-f"></i></a>
        <a class="btn btn-outline-light btn-floating m-1" href="https://github.com/" role="button"><i
            class="fa-brands fa-github"></i></a>
        <a class="btn btn-outline-light btn-floating m-1" href="https://www.google.com.tw/" role="button"><i
            class="fab fa-google"></i></a>
        <a class="btn btn-outline-light btn-floating m-1" href="https://www.instagram.com/" role="button"><i
            class="fab fa-instagram"></i></a>
        <a class="btn btn-outline-light btn-floating m-1" href="https://tw.linkedin.com/" role="button"><i
            class="fab fa-linkedin-in"></i></a>
      </div>
    </div>
    <div class="footer">
      <span class="col-lg-12">CONTACT US</span><br>
      <span>
        <a class="col-lg-6" href="tel:+8864-2251-8125" target="_blank">
          <i class="fa-solid fa-phone "></i>
          ：04-2251-8125
        </a>
        &nbsp;&nbsp;&nbsp;
        <a class=" col-lg-6" href="mailto:millovepasta@gmail.com" target="_blank">
          <i class="fa-solid fa-envelope"></i>
          ：ReadUse@gmail.com</a>
      </span><br>
      <span>
        <a class=" col-lg-12" href="https://goo.gl/maps/inqeeVHZ8dYe7oCHA" target="_blank">
          <i class="fa-solid fa-location-dot"></i>
          ：408台中市南屯區河南路四段350巷23號
        </a>
      </span>
    </div>


    <div class="text-center p-3 bg-dark">
      © 2023 Copyright : ReadUse.com
    </div>
  </div>
</template>

<script>
export default {
  name: 'NavFooter',
  methods: {
    scrollToTop: function () {
      window.scrollTo({
        top: 0,
        behavior: 'smooth'
      });
    },
  },
  async created() {
    window.addEventListener('scroll', () => {
        const scrollY = window.scrollY;
        if (scrollY > 200) {
            $("#scrollButton").removeClass('hidden');
        } else {
            $("#scrollButton").addClass('hidden');
        }
    });
  }
}
</script>