/*
 * @Author: your name
 * @Date: 2020-12-12 12:50:17
 * @LastEditTime: 2020-12-17 09:47:17
 * @LastEditors: Please set LastEditors
 * @Description: In User Settings Edit
 * @FilePath: \vue-element-admin\src\network\info\user.js
 */
import { request } from '../httpPromise'

export  function getName(id){
    return request({
        url:'first/'+id,
        method: 'get',
        // params:{id :id}
    })
}
export function getType(){
    return request({
        url:'/get',
        method: 'get',
        // params:{id :id}
    })
}
export function addArticle(article){
    return request({
        url:'/addArticle',
        method: 'post',
        data:article
        // params:{id :id}
    })
}
//在页面中调用