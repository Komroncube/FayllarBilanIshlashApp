namespace FayllarBilanIshlash.Services
{
    public interface IFileService
    {
        public string UploadImage(IFormFile file);
        public byte[] DownloadImage(string path);
    }
}
