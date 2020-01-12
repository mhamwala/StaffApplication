using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThreeAmigosPurchase.Services
{
    public class FakePurchaseService : IPurchaseService
    {
        public List<PurchaseDto> _purchase = new List<PurchaseDto>
        {
    new PurchaseDto {
        Id = 1,
        productID = 12,
        ProductQuantity = 23.0,
        status = true },
    new PurchaseDto
    {
        Id = 2,
        productID = 12,
        ProductQuantity = 23.0,
        status = true
    },
    new PurchaseDto
    {
        Id = 3,
        productID = 12,
        ProductQuantity = 23.0,
        status = true
    },
    new PurchaseDto
    {
        Id = 4,
        productID = 12,
        ProductQuantity = 23.0,
        status = true
    }
        };

        public Task<IEnumerable<PurchaseDto>> GetPurchaseAsync()
        {
            return Task.FromResult(_purchase.AsEnumerable());
        }

        Task<PurchaseDto> IPurchaseService.GetPurchaseDetailsAsync(int Id)
        {
            var purchase = _purchase.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(purchase);
        }

        Task<PurchaseDto> IPurchaseService.PostPurchaseAsync(PurchaseDto purchase)
        {
            _purchase.Add(purchase);
            return Task.FromResult(purchase);
        }

        Task<PurchaseDto> IPurchaseService.PutPurchaseAsync(PurchaseDto purchase)
        {
            _purchase.Add(purchase);
            return Task.FromResult(purchase);
        }

        Task<PurchaseDto> IPurchaseService.EditPurchaseDetailsAsync(int Id)
        {
            var purchase = _purchase.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(purchase);
        }

        public Task<PurchaseDto> GetDeletePurchaseAsync(int Id)
        {
            var purchase = _purchase.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(purchase);
        }

        public Task<IEnumerable<PurchaseDto>> GetPurchasesAsync(int Id)
        {
            return Task.FromResult(_purchase.AsEnumerable());
        }

        public Task<PurchaseDto> DeletePurchaseAsync(int Id)
        {
            var purchase = _purchase.FirstOrDefault(r => r.Id == Id);
            return Task.FromResult(purchase);
        }

        public bool GetPurchaseExists(int Id)
        {
            return true;
        }
    }
}
