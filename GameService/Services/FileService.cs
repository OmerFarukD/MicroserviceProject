using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using GameService.Dtos.Games;
using GameService.Options;
using Microsoft.Extensions.Options;

namespace GameService.Services;

public class FileService : IFileService
{
    private Cloudinary _cloudinary;
    private Account _account;
    private CloudinarySettings _cloudinarySettings;
    
    public FileService(IOptions<CloudinarySettings> cloudOptions)
    {
        _cloudinarySettings = cloudOptions.Value;
        _account = new Account(_cloudinarySettings.CloudName,_cloudinarySettings.ApiKey,_cloudinarySettings.ApiSecret);

        _cloudinary = new Cloudinary(_account);
        _cloudinary.Api.Client.Timeout = TimeSpan.FromMinutes(30);

    }
    
    
    
    public async Task<string> UploadVideo(IFormFile file)
    {
        var uploadResult = new VideoUploadResult();
        if (file.Length>0)
        {
            using var stream = file.OpenReadStream();

            var uploadParams = new VideoUploadParams()
            {
                File = new FileDescription(file.FileName,stream),
                Folder = "g-store_microservice"
            };

            uploadResult = await _cloudinary.UploadAsync(uploadParams);
            string videoUrl = _cloudinary.Api.UrlVideoUp.BuildUrl(uploadResult.PublicId);

            return videoUrl;
        }

        return string.Empty;
    }

    public async Task UploadImage()
    {
       
    }
}