<!--
 * @Author: your name
 * @Date: 2020-12-17 14:08:43
 * @LastEditTime: 2020-12-17 15:14:38
 * @LastEditors: Please set LastEditors
 * @Description: In User Settings Edit
 * @FilePath: \vue-element-admin\src\views\infomation\components\upload-cover.vue
-->
<!-- 组件说明 -->
<template>
    <div class='upload-cover'>
        <div class="cover-wrap">
      <img
        class="cover-image"
        ref="cover-image"
       
      >
    </div>
    </div>
</template>

<script>
    //import x from ''
    export default {
        name:"upload-cover",
        components: {

        },
        data () {
            return {

            };
        },
        computed: {

        },
        methods: {

        },
mounted() {

},
beforeCreate() {}, //生命周期 - 创建之前
beforeMount() {}, //生命周期 - 挂载之前
beforeUpdate() {}, //生命周期 - 更新之前
updated() {}, //生命周期 - 更新之后
beforeDestroy() {}, //生命周期 - 销毁之前
destroyed() {}, //生命周期 - 销毁完成
activated() {}, //如果页面有keep-alive缓存功能，这个函数会触发
    }
</script>

<style lang='scss' src=''>
.cover-wrap {
  width: 150px;
  height: 120px;
  border: 1px solid #000;
  /* label-width="100px"和label-width宽度一样 */
  margin-left: 100px;
  margin-bottom: 30px;
  .cover-image {
    height: 120px;
    max-width: 100%;
  }
}

</style>