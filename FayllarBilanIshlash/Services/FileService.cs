
namespace FayllarBilanIshlash.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _environment;

        public FileService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public byte[] DownloadImage(string path)
        {
            string fullpath = _environment.WebRootPath + path;
            return File.ReadAllBytes(fullpath);
        }

        public string UploadImage(IFormFile file)
        {
            string extension = Path.GetExtension(file.FileName);
            string path = Path.Combine("/Images", Guid.NewGuid().ToString()+extension);

            string fullPath = _environment.WebRootPath + path;

            using(FileStream fileStream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return path;
        }
    }
}
