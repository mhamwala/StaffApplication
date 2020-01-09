using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThreeAmigosPurchase.Services
{
    public interface IPurchaseService
    {
        Task<IEnumerable<PurchaseDto>> GetPurchaseAsync();

        Task<IEnumerable<PurchaseDto>> GetPurchasesAsync(int Id);

        Task<PurchaseDto> GetPurchaseDetailsAsync(int Id);

        bool GetPurchaseExists(int Id);

        Task<PurchaseDto> PutPurchaseAsync(PurchaseDto purchaseDto);

        Task<PurchaseDto> PostPurchaseAsync(PurchaseDto PurchaseDto);

        Task<PurchaseDto> EditPurchaseDetailsAsync(int Id);

        Task<PurchaseDto> GetDeletePurchaseAsync(int Id);

        Task<PurchaseDto> DeletePurchaseAsync(int Id);
    }
}
