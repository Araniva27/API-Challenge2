namespace RSMEnterpriseIntegrationsAPI.Application.DTOs
{
    public class UpdateSalesOrderHeaderDto
    {        
        public int SalesOrderId { get; set; } 
        public byte RevisionNumber { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; } = DateTime.Now;          
        public decimal SubTotal { get; set;}
        public decimal TaxAmt { get; set; }
        public decimal Freight { get; set; }
    }
}
