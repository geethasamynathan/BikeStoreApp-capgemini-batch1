using BikeStoreApp_BackEnd.Models;

namespace BikeStoreApp_BackEnd.IServices
{
    public interface ISalesService
    {
        Task<IEnumerable<SalesReport>> GetSalesReports(string frequency);

    }
}
