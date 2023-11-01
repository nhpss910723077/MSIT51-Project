import { createRouter, createWebHistory } from 'vue-router'

const routes = [
  {
    path: '/',
    name: 'home',
    component: () => import('../views/HomeView.vue')
  },
  {
    path: '/product/lists/:id?',
    name: 'productList',
    component: () => import('../views/ProductListView.vue')
  },
  {
    path: '/product/content/:id/:cid',
    name: 'productContent',
    component: () => import('../views/ProductContentView.vue')
  },
  {
    path: '/news/lists/:id',
    name: 'newsList',
    component: () => import('../views/NewsListView.vue')
  },
  {
    path: '/news/content/:id',
    name: 'newsContent',
    component: () => import('../views/NewsContentView.vue')
  },
  {
    path: '/cart/step1',
    name: 'cartStep1',
    component: () => import('../views/CartStep1View.vue')
  },
  {
    path: '/cart/step2',
    name: 'cartStep2',
    component: () => import('../views/CartStep2View.vue')
  },
  {
    path: '/cart/step3',
    name: 'cartStep3',
    component: () => import('../views/CartStep3View.vue')
  },
  {
    path: '/login',
    name: 'login',
    component: () => import('../views/LoginView.vue')
  },
  {
    path: '/register',
    name: 'register',
    component: () => import('../views/RegisterView.vue')
  },
  {
    path: '/password/forget',
    name: 'passwordForget',
    component: () => import('../views/PasswordForgetView.vue')
  },
  
  {
    path: '/member/index',
    name: 'memberIndex',
    component: () => import('../views/MemberIndexView.vue')
  },
  {
    path: '/member/update',
    name: 'MemberUpdate',
    component: () => import('../views/MemberUpdateView.vue')
  },
  {
    path: '/member/favorite',
    name: 'MemberFavorite',
    component: () => import('../views/MemberFavoriteView.vue')
  },
  {
    path: '/member/message',
    name: 'MemberMessage',
    component: () => import('../views/MemberMessageView.vue')
  },
  {
    path: '/member/changePassword',
    name: 'memberChangePassword',
    component: () => import('../views/MemberChangePasswordView.vue')
  },
  {
    path: '/member/order',
    name: 'memberOrder',
    component: () => import('../views/MemberOrderView.vue')
  },
  {
    path: '/member/bookcase',
    name: 'memberBookcaser',
    component: () => import('../views/MemberBookcaseView.vue')
  },
  {
    path: '/member/policy',
    name: 'memberPolicy',
    component: () => import('../views/MemberPolicyView.vue')
  },
  {
    path: '/member/usedBookStep1',
    name: 'memberUsedBookStep1',
    component: () => import('../views/MemberUsedBookStep1View.vue')
  },
  {
    path: '/member/usedBookStep2',
    name: 'memberUsedBookStep2',
    component: () => import('../views/MemberUsedBookStep2View.vue')
  },
  {
    path: '/member/usedBookStep3',
    name: 'memberUsedBookStep3',
    component: () => import('../views/MemberUsedBookStep3View.vue')
  },
  {
    path: '/member/usedSeek',
    name: 'memberUsedSeek3',
    component: () => import('../views/MemberUsedSeekView.vue')
  },
  {
    path: '/back',
    name: 'back',
    component: () => import('../views/BackView.vue')
  },
  {
    path: '/back/lists/:modelName',
    name: 'backLists',
    component: () => import('../views/BackListView.vue')
  },
  {
    path: '/back/create/:modelName',
    name: 'backCreate',
    component: () => import('../views/BackContentView.vue')
  },
  {
    path: '/back/edit/:modelName/:id',
    name: 'backEdit',
    component: () => import('../views/BackContentView.vue')
  },
  {
    path: '/valid/:memberID/:vcode',
    name: 'valid',
    component: () => import('../views/ValidView.vue')
  },
  {
    path: '/member/Logout',
    name: 'memberLogout',
    component: () => import('../views/MemberLogoutView.vue')
  },
   /*
  {
    path: '/XXXXX/XXXXX',
    name: 'productContent',
    component: () => import('../views/ProductContentView.vue')
  },
  */

]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
