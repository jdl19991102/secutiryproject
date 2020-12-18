using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSecurity.Interface;
using WebSecurity.Service;
using WebSecurity.Model;
using Dapper;
using Microsoft.AspNetCore.Cors;
using WebSecurity.Interface.Extend;
using Microsoft.Extensions.Logging;
using System.IO;

namespace WebSecurity.Controllers
{
    [EnableCors("any")]
    [Route("[controller]")]
    [ApiController]
    public class FirstController : ControllerBase
    {


        //private readonly ImagesResource _imagesResource;

        //private readonly ILogger<FirstController> _logger;
        private readonly IUserService _iUserService;

        public FirstController(
             IUserService iUserService)
        {
          
            _iUserService = iUserService;
        }

      
        /// <summary>
        /// 根据id查询用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Users Get(int id)
        {
            var user = _iUserService.Get<Users>(id);
            return user;

        }

        

        [HttpPost]
        public void Post(IFormFile File)
        {

        }

        ///// <summary>
        ///// 批量上传图片
        ///// </summary>
        ///// <param name="file"></param>
        ///// <param name="formCollection"></param>
        //[HttpPost("{formFile}", Name = "Image")]
        //public IActionResult Post([FromForm] IFormFileCollection formCollection)
        //{
        //    IList<CustomStatusCode> code = new List<CustomStatusCode>();
        //    if (formCollection.Count > 0)
        //        foreach (IFormFile file in formCollection)
        //        {
        //            var currentCode = _imagesResource.UpLoadPhoto(file, @"\images\6\");
        //            code.Add(currentCode);
        //        }

        //    return StatusCode(200, code);
        //}

        ///// <summary>
        ///// 获取图片
        ///// </summary>
        ///// <param name="imgName"></param>
        ///// <returns></returns>
        //[HttpGet]
        //public IActionResult Get(string imgName)
        //{
        //    var image = _imagesResource.LoadingPhoto("\\Images\\6\\", imgName);
        //    if (image == null)
        //    {
        //        _logger.LogInformation($"图片 {imgName} 不存在");
        //        var code = new CustomStatusCode
        //        {
        //            Status = "404",
        //            Message = $"图片 {imgName} 加载不存在"
        //        };
        //        return StatusCode(404, code);
        //    }

        //    return image;

        //    #region MyRegion

        //    /*string[] LimitPictureType =
        //        {".PNG", ".JPG", ".JPEG", ".BMP", ".GIF", ".ICO"};
        //    GetFileName(di);





        //    string path = Directory.GetCurrentDirectory()+ $@"\Images\6\{imgName}"+".jpeg";

        //    FileInfo fi = new FileInfo(path);
        //    FileStream fs = fi.OpenRead(); ;
        //    byte[] buffer = new byte[fi.Length];
        //    //读取图片字节流
        //    fs.Read(buffer, 0, Convert.ToInt32(fi.Length));
        //    var response = File(buffer, "image/jpeg");
        //    fs.Close();
        //    return response;
        //    */

        //    #endregion
        //}

        //private static IList<string> path = new List<string>(); //保存你图片名称
        //DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory() + @"\Images\6\");

        ///// <summary>
        ///// 加载目录内文件夹名
        ///// </summary>
        ///// <param name="info"></param>
        //public static void GetFileName(DirectoryInfo info)
        //{
        //    //获取该路径下的所有文件的列表
        //    FileInfo[] fileInfo = info.GetFiles();

        //    //开始得到图片名称
        //    foreach (FileInfo subinfo in fileInfo)
        //    {
        //        //判断扩展名是否相同
        //        // if (subinfo.Extension == extension)
        //        // {
        //        string strname = subinfo.Name; //获取文件名称

        //        path.Add(strname); //把文件名称保存在泛型集合中
        //                           // }
        //    }
        //}
    }
}

