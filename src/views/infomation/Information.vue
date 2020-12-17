<!--
 * @Author: your name
 * @Date: 2020-12-10 12:04:21
 * @LastEditTime: 2020-12-17 15:59:53
 * @LastEditors: Please set LastEditors
 * @Description: In User Settings Edit
 * @FilePath: \vue-element-admin\src\views\infomation\Information.vue
-->
<template>
  <div class="AddArt">
    <el-form
      ref="ruleForm"
      label-width="100px"
      class="demo-ruleForm"
    >
      <el-form-item label="活动名称" prop="name">
        <el-input v-model="article.title"></el-input>
      </el-form-item>

       <el-form-item label="活动形式" prop="desc">
        <el-input type="textarea" v-model="article.contents"></el-input>
      </el-form-item>
      
      <el-form-item label="频道" prop="region">
        <el-select v-model="article.source" placeholder="请选择活动区域" >
          <el-option :label="item.newsTypeCN" :value="item.newsType" v-for=" (item,index) in nameType" :key="index"></el-option>
         
        </el-select>
      </el-form-item>
      
    
        
        
      <el-form-item>
        <el-button type="primary" @click="onPublish()"
          >立即创建</el-button
        >
        <el-button @click="resetForm('article')">重置</el-button>
      </el-form-item>
      
    </el-form>
  </div>
</template>
<script type="text/ecmascript-6">
import { getName,getType,addArticle } from "@/network/info/user";

export default {
  components:{
    
  },
  data() {
    return {
      
      article:{
        title:"",
        contents:"",
        source:""
      },
      nameType:[]
    };
  },
  mounted() {
    // getName(1).then((res) => {
    //   console.log(res);
    // });
    getType().then(res=>{
      this.nameType.push(...res.data)
      
    })
  },
  methods: {
    onPublish() {
      console.log(this.article);
      addArticle(this.article).then(res=>{
        console.log();
      })
     
    },
    resetForm(formName) {
      this.$refs[formName].resetFields();
    },
  },
};
</script>
