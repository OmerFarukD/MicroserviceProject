using GameService.Dtos.Games;

namespace GameService.Services;

public interface IFileService
{
    Task<string> UploadVideo(IFormFile formFile);
    Task UploadImage();
}