using FayllarBilanIshlash.DTOs;

namespace FayllarBilanIshlash.Services
{
    public interface IProductService
    {
        public void CreateProduct(ProductCommandDto productCommandDto);
        public ProductResponseDto GetProductWithImage(int Id);
        public ProductResponseDto GetProduct(int Id);
    }
}
