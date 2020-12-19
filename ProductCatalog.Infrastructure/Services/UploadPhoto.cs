using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Infrastructure.Services
{
     public class UploadPhoto
    {
    //    public async Task<string> UploadProfilePicture([FromForm(Name = "uploadedFile")] IFormFile file, long userId)
    //    {
    //        if (file == null || file.Length == 0)
    //            throw new UserFriendlyException("Please select profile picture");

    //        var folderName = Path.Combine("Resources", "ProfilePics");
    //        var filePath = Path.Combine(Directory.GetCurrentDirectory(), folderName);

    //        if (!Directory.Exists(filePath))
    //        {
    //            Directory.CreateDirectory(filePath);
    //        }

    //        var uniqueFileName = $"{userId}_profilepic.png";
    //        var dbPath = Path.Combine(folderName, uniqueFileName);

    //        using (var fileStream = new FileStream(Path.Combine(filePath, uniqueFileName), FileMode.Create))
    //        {
    //            await file.CopyToAsync(fileStream);
    //        }

    //        return dbPath;
    //    }
    }
}
