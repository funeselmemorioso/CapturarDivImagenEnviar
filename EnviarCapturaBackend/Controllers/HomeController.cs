using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EnviarCapturaBackend.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }        

        [HttpPost]
        public async Task<ActionResult> RecibirFoto(String imageData)
        {
            string fileNameWitPath = Server.MapPath("~/fotos/mifoto.png");
            try
            {
                using (FileStream fs = new FileStream(fileNameWitPath, FileMode.Create))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        byte[] data = Convert.FromBase64String(imageData);                        
                        bw.Write(data);
                        bw.Close();
                    }
                }
                return Json("true");
            }
            catch (Exception)
            {
                return Json("false");
                throw;
            }          

        }

    }
}