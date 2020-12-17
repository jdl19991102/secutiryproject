<<<<<<< HEAD
<!--
 * @Author: your name
 * @Date: 2020-12-08 15:42:07
 * @LastEditTime: 2020-12-10 11:48:35
 * @LastEditors: Please set LastEditors
 * @Description: In User Settings Edit
 * @FilePath: \vue-element-admin\src\views\layout\Sidebar.vue
-->
=======
>>>>>>> 82538a700f39e8595d8ad2a3d2e77253d526449e
<template>
	<el-menu mode="vertical" theme="dark" :default-active="$route.path">
		<sidebar-item :routes='permission_routers'></sidebar-item>
	</el-menu>
</template>

<script>
  import { mapGetters } from 'vuex';
  import SidebarItem from './SidebarItem';
  export default {
    components: { SidebarItem },
    computed: {
      ...mapGetters([
        'permission_routers'
      ])
    }
  }
</script>

<style rel="stylesheet/scss" lang="scss" scoped>
	.el-menu {
			min-height: 100%;
	}
</style>
