<template>
  <nav id="header" class="navbar navbar-expand-lg">
    <div class="container-fluid">

      <a class="navbar-brand" href="/">
        <img :src="`/images/Logo.png`">
      </a>

      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent"
        aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>

      <div class="collapse navbar-collapse" id="navbarSupportedContent">
        <ul class="navbar-nav me-auto mb-2 mb-lg-0"></ul>
        <div>
          <ul class="navbar-nav me-auto mb-2 mb-lg-0">
            <li class="head-right-box">
              <form method="get" action="/product/lists">
                <div class="search">
                  <input id="searchInput" name="search" type="text" placeholder="Search . . .">
                </div>
              </form>
            </li>
            <li class="nav-item head-right-box">
              <a class="nav-link" href="/news/lists/1">最新消息</a>
            </li>
            <li class="nav-item head-right-box">
              <a class="nav-link" href="/product/lists/0">館藏分類</a>
            </li>
            <li class="nav-item head-right-box">
              <a class="nav-link" href="/product/lists/-1">二手書</a>
            </li>
            <template v-if="islogin">
              <li id="headLogin" class="nav-item head-right-box">
                <a class="nav-link" href="/login">登入</a>
              </li>
              <li id="headRegister" class="nav-item head-right-box">
                <a class="nav-link" href="/register">註冊</a>
              </li>
            </template>
            <template v-else>
              <li id="headMemberTEST" class="nav-item head-right-box">
                <a class="nav-link" href="/member/index">會員中心</a>
              </li>
              <li class="nav-item head-right-box">
              <a class="nav-link fa-solid fa-cart-shopping" href="/cart/step1">
                <span id="cartCounter" class="badge badge-notify cart-badge"></span>
              </a>
            </li>
            </template>
            
          
          </ul>
        </div>
      </div>
    </div>
  </nav>
</template>

<script>
export default {
  name: 'NavHeader',
  data() {
    return {
      islogin: true,
    }
  },
  async created() {
    var self = this;


    //判斷是否為登入狀態
    if (sessionStorage.getItem('MemberID') != null) {
      this.islogin = false;
    }
    else {
      this.islogin = true;
    }

   
  }
}
</script>