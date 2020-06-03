using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QRCoder;
using QRService.Model;

namespace QRService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QRGeneratorController : ControllerBase
    {
        private readonly ILogger<QRGeneratorController> _logger;

        //  private Jelovnik jelovnik = new Jelovnik();

        

        public QRGeneratorController(ILogger<QRGeneratorController> logger)
        {
            _logger = logger;
        }


        [HttpPost]
        public ActionResult<QRImage> Test(QRDataCatering file)
        {
           // parseXML(file);
           var bitmap= generateQRCode(file);

          var imageInBytes =  bitmapToBytes(bitmap);

            QRImage image = new QRImage();
            image.QRImageInBytes = imageInBytes;
          
            return image;
        }

        private Bitmap generateQRCode(QRDataCatering file)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("Prvi obrok je: " + file.CateringName, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(10);

            return qrCodeImage;
        }

        //private void parseXML(IFormFile file)
        //{
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(file.FileName);




        //    XmlNodeList nodes = doc.DocumentElement.SelectNodes("/qRDataCatering");

        //    var enumerator = nodes.GetEnumerator();

        

        //    foreach (XmlNode node in nodes)
        //    {
        //        jelovnik.CateringName = node.SelectSingleNode("CateringName").InnerText;
               
        //    }
        //}

      
        private static byte[] bitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

    }






}