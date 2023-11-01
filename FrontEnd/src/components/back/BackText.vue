<template>
  {{content['item'][field['FieldName']]}}
</template>

<script>
export default {
  name: 'BackText',
  props: ["index", "field", "content"]
}
</script>

<style scoped src="./css/BackComponents.css"></style>