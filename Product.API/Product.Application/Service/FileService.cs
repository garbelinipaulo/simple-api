using Microsoft.Extensions.Logging;
using Product.Application.Domain.Contracts.Notification;
using Product.Application.Domain.Contracts.Service;
using Product.Application.Service.Base;
using System.Text.RegularExpressions;

namespace Product.Application.Service
{
    public class FileService : BaseService<ProductService>, IFileService
    {
        public FileService(
          ILogger<ProductService> logger,
          INotificator notify) : base(logger, notify)
        { 
        }


        /// <summary>
        /// Main method to send file to some ftp/server
        /// </summary>
        /// <param name="base64"></param>
        /// <param name="fileName"></param>
        /// <param name="folderPath"></param>
        /// <returns></returns>
        public async Task<string> UploadFileAsync(string base64, string fileName)
        {
            try
            {
                string _base64File = string.Empty;

                if (base64.Contains("data:image"))
                {
                    _base64File = Regex.Match(base64, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
                }
                else if (base64.Contains("data:application/pdf"))
                {
                    _base64File = Regex.Match(base64, @"data:application/pdf;(?<type>.+?),(?<data>.+)").Groups["data"].Value;
                }
                else if (base64.Contains("data:application/x-zip-compressed"))
                {
                    _base64File = Regex.Match(base64, @"data:application/x-zip-compressed;(?<type>.+?),(?<data>.+)").Groups["data"].Value;
                }
                _base64File = _base64File.Replace(" ", "+");
                var _binImg = Convert.FromBase64String(_base64File);


                ///send to some ftp server and them return the path

                return $"generic_url";
            } 
            catch (Exception e)
            {
                return string.Empty;
            } 
        }
    }
}
