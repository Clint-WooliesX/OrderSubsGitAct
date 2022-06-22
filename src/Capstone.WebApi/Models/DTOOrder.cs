namespace Capstone.WebApi.Models
{
    public class DTOOrder
    {
        //public IList<OrderLineItemModel> LineItems { get; set; }
       
        public int stockCode { get; set; }

        public string fulfilmentStoreKey { get; set; }

        public double quantity { get; set; }

        public string branchID { get; set; }

        
    }
}
