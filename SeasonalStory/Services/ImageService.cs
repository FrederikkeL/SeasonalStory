using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeasonalStory.Services
{
    public class ImageService
    {
        public byte[] ConvertToByteArray(IFormFile tempUploadedFile)
        {
            // Get a temporary file path
            var tempFilePath = Path.Combine(Path.GetTempPath(), tempUploadedFile.FileName);

            // Save the file to the temporary path
            using (FileStream fs = new FileStream(tempFilePath, FileMode.Create))
            {
                tempUploadedFile.CopyTo(fs);
            }

            // Read the file bytes
            byte[] fileBytes = File.ReadAllBytes(tempFilePath);

            // Delete the temporary file
            File.Delete(tempFilePath);

            return fileBytes;
        }
    }
}
