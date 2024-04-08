namespace RSMEnterpriseIntegrationsAPI.Application.DTOs
{
    public class UpdateProductCateDto
    {
        public int ProductCategoryId { get; set; }
        public string? Name { get; set; }       
        public DateTime ModifiedDate { get; set; } = DateTime.Now;      
    }
}
