using System;
using System.IO;
using MCMDirect.Areas.Admin.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace MCMDirect.Areas.Admin.Models.ExtensionMethods {
    public static class ImageExtensionMethods {

        

        public static string UploadFile(IFormFile image, string uploadsFolder)
        {
            string uniqueFileName = null;

            
            uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(fileStream);
            }

            return uniqueFileName;
        }

        public static IFormFile ReadImageFile(string filePath)
        {
            using (var stream = System.IO.File.OpenRead(filePath))
            {
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name));
                return file;
            }
        }
    }
}