/*
 * @Author: your name
 * @Date: 2020-12-12 11:50:47
 * @LastEditTime: 2020-12-16 14:17:32
 * @LastEditors: Please set LastEditors
 * @Description: In User Settings Edit
 * @FilePath: \vue-element-admin\src\network\request.js
 */
import config from './config'
class HttpRequest{
    constructor(){
      
        this.baseURL=config.baseURL;
        this.timeout=3000;
    }
    setInterceptors(instance){
        instance.interceptors.use(config=>{
            
            return config;
        });
        instance.interceptors.response.use(res=>{
            if(res.status=200){
                
                return Promise.resolve(res.data);
            }else{
                return Promise.reject(res.data.data);
            }
        },err=>{
            switch (err.response.status) {
                case '401':
                    console.log(err);
                    break;
            
                default:
                    break;
            }
            return Promise.reject(err);
        });
    }
    mergeOptions(options){
        return{
            baseURL:this.this.baseURL,timeout:this.this.timeout,...options
        }
    }
    request (options){
        const instance=axios.create();
        this.setInterceptors(instance)
        const opts=this.mergeOptions(options);

        return instance(opts)
    }
    get(url,config){//路径参数？a=1
        return this.request({
            method:'get',
            url,
            ...config
        })
    }
    post(url,data){//请求体{}
    return this.request({
        method:'post',
        url,
        data:data
    })
    }
}
export default new HttpRequest
