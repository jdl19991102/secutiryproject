using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Text;
using WebSecurity.Interface.Extend;

namespace WebSecurity.Interface
{
   public interface IImageResource
    {
        /// <summary>
        /// 加载图片
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="name">图片名</param>
        /// <returns></returns>
        FileContentResult LoadingPhoto(string path, string name);

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="formFile">图片</param>
        /// <param name="path">路径</param>
        /// <param name="name">图片名字</param>
        /// <returns></returns>
        CustomStatusCode UpLoadPhoto(IFormFile formFile, string path);
    }
}
