using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WebSecurity.Interface.Extend;
using WebSecurity.Interface;

namespace WebSecurity.Service
{
   public class ImagesResource : ControllerBase, IImageResource
    {
        public static string[] LimitPictureType = { ".PNG", ".JPG", ".JPEG", ".BMP", ".ICO" };

        /// <summary>
        /// 加载图片
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public FileContentResult LoadingPhoto(string path, string name)
        {
            path = Directory.GetCurrentDirectory() + path + name + ".jpeg";
            FileInfo fi = new FileInfo(path);
            if (!fi.Exists)
            {
                return null;
            }

            FileStream fs = fi.OpenRead();
            byte[] buffer = new byte[fi.Length];
            //读取图片字节流
            //从流中读取一个字节块，并在给定的缓冲区中写入数据。
            fs.Read(buffer, 0, Convert.ToInt32(fi.Length));
            var resource = File(buffer, "image/jpeg");
            fs.Close();
            return resource;
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="formFile"></param>
        /// <param name="path">路劲</param>
        /// <returns></returns>
        public CustomStatusCode UpLoadPhoto(IFormFile formFile, string path)
        {
            CustomStatusCode code;
            var currentPictureWithoutExtension = Path.GetFileNameWithoutExtension(formFile.FileName);
            var currentPictureExtension = Path.GetExtension(formFile.FileName).ToUpper();
            path = Directory.GetCurrentDirectory() + path;
            if (LimitPictureType.Contains(currentPictureExtension))
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string name = currentPictureWithoutExtension + ".jpeg";
                path += name;
                using (var fs = System.IO.File.Create(path))
                {
                    formFile.CopyTo(fs);
                    //Stream 都有 Flush() 方法，
                    //根据官方文档的说法
                    //“使用此方法将所有信息从基础缓冲区移动到其目标或清除缓冲区，或者同时执行这两种操作”
                    fs.Flush();
                }
                code = new CustomStatusCode
                {
                    Status = "200",
                    Message = $"图片 {name} 上传成功"
                };
                return code;
            }
            code = new CustomStatusCode
            {
                Status = "400",
                Message = $"图片上传失败，格式错误"
            };
            return code;
        }
    }
}
