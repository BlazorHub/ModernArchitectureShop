using System;
using System.Linq;
using ModernArchitectureShop.Store.Domain;

namespace ModernArchitectureShop.Store.Infrastructure.Persistence
{
    public sealed class SeedDataGenerator
    {
        internal static void GenerateSeed(StoreDbContext deStoreDbContext)
        {
            if (deStoreDbContext.Stores.Any())
            {
                // do not seed, if the database has any data
                return;
            }

            var store = new Domain.Store
            {
                StoreId = Guid.NewGuid(),
                Name = $"Store In Germany",
            };

            var address = new Address
            {
                AddressId = Guid.NewGuid(),
                City = "city",
                State = "St",
                StreetAddress = "Str",
                ZipCode = "911",
                IsMainAddress = true
            };

            store.Addresses.Add(address);

            for (var i = 10; i < 100; i++)
            {
                var product = new Product
                {
                    ProductId = new Guid($"12345678-1234-1234-1234-1234567891{i}"),
                    Code = $"11{i}",
                    Name = $"Products-{i}",
                    Price = 3.14 * i,
                    ImageUrl = "/images/MyProduct.png",
                    Quantity = 10,
                    Store = store
                };

                store.Products.Add(product);
            }

            deStoreDbContext.Stores.Add(store);
        }
    }
}
