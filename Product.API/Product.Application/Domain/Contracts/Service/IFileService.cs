namespace Product.Application.Domain.Contracts.Service
{
    public interface IFileService
    {
        Task<string> UploadFileAsync(string base64, string fileName);
    }
}
