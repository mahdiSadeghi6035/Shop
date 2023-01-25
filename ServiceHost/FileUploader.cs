using _0_Framework.Application;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace ServiceHost
{
    public class FileUploader : IFileUploader
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileUploader(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string Upload(IFormFile formFile, string path)
        {
            if(formFile == null) return null;
            string directory = $"{_webHostEnvironment.WebRootPath}//fileUploader//{path}";
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            string fileName = $"{DateTime.Now.ToFileName()}-{formFile.FileName}";
            string filePath = $"{directory}//{fileName}";
            using var output = File.Create(filePath);
            formFile.CopyTo(output);
            return $"{path}//{fileName}";
        }
    }
}
