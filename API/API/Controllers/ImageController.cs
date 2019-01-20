using API.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class ImageController : ApiController
    {
        [HttpPost]
        public string ImageToGrayscale ([FromBody] JObject base64)
        {
            Bitmap image = ImageProcessor.Base64ToBitmap(base64["base64"].ToString());
            Bitmap grayscale = ImageProcessor.ConvertToGrayScale(image);
            return ImageProcessor.BitmapToBase64(grayscale);
        }

        [HttpPost]
        public string InvertColor([FromBody] JObject base64)
        {
            Bitmap image = ImageProcessor.Base64ToBitmap(base64["base64"].ToString());
            Bitmap inverted = ImageProcessor.InvertColor(image);
            return ImageProcessor.BitmapToBase64(inverted);
        }

        [HttpPost]
        public string DarkenImage([FromBody] JObject base64)
        {
            Bitmap image = ImageProcessor.Base64ToBitmap(base64["base64"].ToString());
            Bitmap darkened = ImageProcessor.DarkenImage(image);
            return ImageProcessor.BitmapToBase64(darkened);
        }
    }
}
