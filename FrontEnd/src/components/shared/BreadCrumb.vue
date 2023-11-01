<template>
  <div class="container">
    <div class="row">
      <div class="col-12">
        <nav style="--bs-breadcrumb-divider: '>';" aria-label="breadcrumb">
          <ol class="breadcrumb">
            <li class="breadcrumb-item" :class="{ active: item.link == '' }" v-for="(item, index) in data">
              <template v-if="item.link != ''">
                <a :href="item.link">{{ item.title }}</a>
              </template>
              <template v-else>
                {{ item.title }}
              </template>
            </li>
          </ol>
        </nav>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'BreadCrumb',
  props: ["data"],
}
</script>

<style scoped>
.breadcrumb li {
  font-size: 20px;
}
.breadcrumb-item{
  color: black;
}
.breadcrumb-item a{
  color: var(--bg-color1);
}
.breadcrumb-item a:hover{
  color: black;
}
</style>