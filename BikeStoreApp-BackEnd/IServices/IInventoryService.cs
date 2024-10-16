using BikeStoreApp_BackEnd.Models;

namespace BikeStoreApp_BackEnd.IServices
{
    public interface IInventoryService
    {
        Task AddInventoryDetails(Inventory inventory);
        Task DeleteInventoryDeatils(int id);
        Task UpdateInventoryDetails(Inventory inventory);
        Task<IEnumerable<Inventory>> ViewAllInventoryDetails();
        Task<Inventory> ViewInventoryDetailsForASpecificProduct(int productId);
    }
}
