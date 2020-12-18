using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebSecurity.Interface;
using WebSecurity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Hosting.Server.Features;

namespace WebSecurity.Controllers
{
    [EnableCors("any")]

    [Obsolete]
    [Route("[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IServerAddressesFeature _serverAddressesFeature;
        public ArticleController(IArticleService articleService, IHostingEnvironment hostingEnvironment, IServerAddressesFeature serverAddressesFeature)
        {
            _articleService = articleService;
            _hostingEnvironment = hostingEnvironment;
            _serverAddressesFeature = serverAddressesFeature;
        }

        [HttpPost("/uploadCover")]
        public async Task<string> post(IFormFile file)
        {
          return  await  uploadCover(file, _hostingEnvironment);

        }

        public async static Task<string> uploadCover(IFormFile Photo,  IHostingEnvironment _hostingEnvironment)
        {


            string newfilename = "";
            if (Photo != null)
            {
                string fileExt = Path.GetExtension(Photo.FileName);
                string webRootPath = _hostingEnvironment.WebRootPath;
                newfilename = System.Guid.NewGuid().ToString() + fileExt;
                string newpa = webRootPath + "\\LunboImg\\";
                if (!Directory.Exists(newpa))
                {
                    Directory.CreateDirectory(newpa);
                }
                string filepath = webRootPath + "\\LunboImg\\" + newfilename;
                using (FileStream filestream = new FileStream(filepath, FileMode.Create))
                {
                    await Photo.CopyToAsync(filestream);
                };
            }
            return newfilename;
        }



        [HttpGet("/get")]
        public IEnumerable< article>  Get()
        {
            string sql = "select distinct newsTypeCN,newsType from  Article  ";
           var typeList= _articleService.Query<article>(sql);

            if (typeList == null)
            {
                //默认类型null
                return default;
            }
            else
            {
                return typeList;
            }
        }

        [HttpPost("/addArticle")]
        public bool post(article art )
        {
            //https://localhost:44361/lunboimg/50cfbed3-ffd9-4d66-bb99-8cf2aee22f31.jpg

            art.date = System.DateTime.Now;
            art.firstImage= _serverAddressesFeature.Addresses.LastOrDefault()+"lunboimg/"+art.firstImage;
            return _articleService.Insert(art);

        }



    }
}
