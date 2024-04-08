namespace RSMEnterpriseIntegrationsAPI.Domain.Interfaces
{
    using RSMEnterpriseIntegrationsAPI.Application.DTOs;    

    public interface IProductCategoryService
    {
        Task<GetProductCateDto?> GetProductCategoryById(int id);
        Task<IEnumerable<GetProductCateDto>> GetAll();
        Task<int> CreateProductCategory(CreateProductCateDto productCategoryDto);
        Task<int> UpdateProductCategory(UpdateProductCateDto productCategoryDto);
        Task<int> DeleteProductCategory(int id);
    }
}
