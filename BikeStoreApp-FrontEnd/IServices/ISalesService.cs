//using BikeStoreApp_BackEnd.Models;
using BikeStoreApp_FrontEnd.Models;

namespace BikeStoreApp_BackEnd.IServices
{
    public interface ISalesService
    {
        Task<IEnumerable<SalesReport>> GetSalesReports(string frequency);

    }
}
