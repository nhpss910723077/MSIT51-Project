<template>
  <NavHeader />
  <router-view/>
  <NavFooter />
</template>

<script>
// @ is an alias to /src
import NavHeader from '@/components/shared/NavHeader.vue'
import NavFooter from '@/components/shared/NavFooter.vue'

export default {
  name: 'App',
  components: {
    NavHeader,
    NavFooter,
  }
}
</script>