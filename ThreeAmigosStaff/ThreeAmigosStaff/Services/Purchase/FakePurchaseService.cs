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
            new PurchaseDto { Id = 21, ProductName = "Ballons", UserId = 1, UserName = "Musa Hamwala", Quantity = 23, Date = 22/04/2019, Price = 14.23, Accepted = false },
            new PurchaseDto { Id = 22, ProductName = "Fish", UserId = 2, UserName = "James Liddle", Quantity = 14, Date = 22/04/2019, Price = 14.23, Accepted = false },
            new PurchaseDto { Id = 23, ProductName = "Carrots", UserId = 3, UserName = "Nathan Williams", Quantity = 100, Date = 22/04/2019, Price = 14.23, Accepted = false },
            new PurchaseDto { Id = 24, ProductName = "Chicken", UserId = 4, UserName = "Conner Basket", Quantity = 2, Date = 22/04/2019, Price = 14.23, Accepted = false }
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
    }
}
