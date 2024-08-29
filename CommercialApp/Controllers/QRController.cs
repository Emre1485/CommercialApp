using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace CommercialApp.Controllers
{
    public class QRController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string code)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator generate = new QRCodeGenerator();
                QRCodeGenerator.QRCode qRCode = generate
                    .CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                using(Bitmap pic = qRCode.GetGraphic(10))
                {
                    pic.Save(ms, ImageFormat.Png);
                    ViewBag.qRCodeImage = "data:image/png;base64," + 
                        Convert.ToBase64String(ms.ToArray());
                }
            }
            return View();
        }
    }
}
