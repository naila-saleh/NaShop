namespace NaShop.Services;

public class ImageService
{
    private string _imageFolderPath;
    public ImageService()
    {
        _imageFolderPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\");
    }
    public string UploadImage(IFormFile image)
    {
        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
        var path = Path.Combine(_imageFolderPath, fileName);
        using (var stream = System.IO.File.Create(path))
        {
            image.CopyTo(stream);
        }
        return fileName;
    }

    public bool DeleteImage(string imageName)
    {
        var path = Path.Combine(_imageFolderPath, imageName);
        if (File.Exists(path))
        {
            File.Delete(path);
            return true;
        }
        return false;
    }
}