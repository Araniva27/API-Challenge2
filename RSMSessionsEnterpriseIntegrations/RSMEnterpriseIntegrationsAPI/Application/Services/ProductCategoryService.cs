namespace RSMEnterpriseIntegrationsAPI.Application.Services
{
    using RSMEnterpriseIntegrationsAPI.Application.DTOs;
    using RSMEnterpriseIntegrationsAPI.Application.Exceptions;
    using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;
    using RSMEnterpriseIntegrationsAPI.Domain.Models;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        public ProductCategoryService(IProductCategoryRepository repository)
        {
            _productCategoryRepository = repository;
        }

        public async Task<int> CreateProductCategory(CreateProductCateDto productCateDto)
        {
            if (productCateDto is null 
                || string.IsNullOrWhiteSpace(productCateDto.Name))                
            {
                throw new BadRequestException("Product Category info is not valid.");
            }

            ProductCategory productCategory = new()
            {                
                Name = productCateDto.Name,
            };

            return await _productCategoryRepository.CreateProductCategory(productCategory);
        }

        public async Task<int> DeleteProductCategory(int id)
        {
            if(id <= 0)
            {
                throw new BadRequestException("Id is not valid.");
            }
            var productCategory = await ValidateProductCategoryExistence(id);
            return await _productCategoryRepository.DeleteProductCategory(productCategory);
        }

        public async Task<IEnumerable<GetProductCateDto>> GetAll()
        {
            var productCategories = await _productCategoryRepository.GetAllProductCategories();
            List<GetProductCateDto> productCateDtos = [];

            foreach (var productCategory in productCategories)
            {
                GetProductCateDto dto = new()
                {
                    ProductCategoryId = productCategory.ProductCategoryId,
                    Name = productCategory.Name,                                        
                };

                productCateDtos.Add(dto);
            }
                        

            return productCateDtos; 
        }

        public async Task<GetProductCateDto?> GetProductCategoryById(int id)
        {
            if(id <= 0)
            {
                throw new BadRequestException("ProductCategoryId is not valid");
            }

            var productCate = await ValidateProductCategoryExistence(id);
            
            GetProductCateDto dto = new()
            {                
                ProductCategoryId = productCate.ProductCategoryId,
                Name = productCate.Name,                
            };
            return dto;
        }

        public async Task<int> UpdateProductCategory(UpdateProductCateDto productCateDto)
        {
            if(productCateDto is null)
            {
                throw new BadRequestException("ProductCategory info is not valid.");
            }
            var productCategory = await ValidateProductCategoryExistence(productCateDto.ProductCategoryId);
            
            productCategory.Name = string.IsNullOrWhiteSpace(productCateDto.Name) ? productCategory.Name : productCateDto.Name;            
        
            return await _productCategoryRepository.UpdateProductCategory(productCategory);
        }

        private async Task<ProductCategory> ValidateProductCategoryExistence(int id)
        {
            var existingProductCategory = await _productCategoryRepository.GetProductCategoryById(id) 
                ?? throw new NotFoundException($"Product Cateogory with Id: {id} was not found.");

            return existingProductCategory;
        }

    }
}
