using System.Drawing;
using System.IO;
using ATM.Utils.HttpContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
/// <summary>
/// QR controller
/// </summary>
public class QR : Controller
{
    /// <summary>
    /// GenerateCodeForString
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    /// 
   
    [HttpGet]
    [Authorize]
    public HttpContextUtils.CommonDataResponse GenerateCodeForString(string input)
    {
        var response = new HttpContextUtils.CommonDataResponse { IsError = false };
                                            
        var qrGenerator = new QRCodeGenerator();
        var qrCodeData = qrGenerator.CreateQrCode(input, QRCodeGenerator.ECCLevel.Q);
        var qrCode = new QRCode(qrCodeData);
        var qrCodeImage = qrCode.GetGraphic(20);
        
        response.Data = GetFileFromBytes(BitmapToBytes(qrCodeImage, input));
    
        return response;
    }    

    private static byte[] BitmapToBytes(Image img, string input)
    {
        using (var stream = new MemoryStream())
        {
            img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            return stream.ToArray();
        }
    }

    private FileResult GetFileFromBytes(byte[] bytesIn)
    {
        return File(bytesIn, "image/png");
        
    }
}