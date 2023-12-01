using FayllarBilanIshlash.Data;
using FayllarBilanIshlash.DTOs;
using FayllarBilanIshlash.Models;

namespace FayllarBilanIshlash.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductDbContext productDbContext;
        private readonly IFileService _fileService;
        public ProductService(ProductDbContext productDbContext, IFileService fileService)
        {
            this.productDbContext = productDbContext;
            _fileService = fileService;
        }

        public void CreateProduct(ProductCommandDto productCommandDto)
        {
            var product = new Product();
            product.Name = productCommandDto.Name;
            product.FilePath = _fileService.UploadImage(productCommandDto.Image);
            productDbContext.Products.Add(product);
            productDbContext.SaveChanges();


        }

        public ProductResponseDto GetProduct(int Id)
        {
            Product product = productDbContext.Products.FirstOrDefault(x => x.Id == Id);
            var response = new ProductResponseDto() { Id = product.Id, Name = product.Name };
            return response;
        }

        public ProductResponseDto GetProductWithImage(int Id)
        {
            Product product = productDbContext.Products.FirstOrDefault(x => x.Id == Id);
            if (product is null)
                return new ProductResponseDto();

            var response = new ProductResponseDto()
            {
                Id = product.Id,
                Name = product.Name,
                Image = _fileService.DownloadImage(product.FilePath)
            };
            return response;
        }
    }
}
