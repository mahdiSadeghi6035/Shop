using _01_ShopQuery.Contract.Product;
using DiscountManagement.Infrastructure.EfCore;
using InventoryManagement.Infrastructure.EfCore;
using ShopManagement.Infrastructure.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_ShopQuery.Query
{
    public class ProductQuery : IProductQuery
    {
        private readonly ShopContext _shopContext;
        private readonly DiscountContext _discountContext;
        private readonly InventoryContext _inventoryContext;

        public ProductQuery(ShopContext shopContext, DiscountContext discountContext, InventoryContext inventoryContext)
        {
            _shopContext = shopContext;
            _discountContext = discountContext;
            _inventoryContext = inventoryContext;
        }

        public IEnumerable<ProductModel> GetProduct()
        {
            var products = _shopContext.Products.Select(x => new ProductModel
            {
                Id = x.Id,
                Slug = x.Slug,
                Name = x.Name,
                Picture = "~/fileUploader/" + x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
            }).OrderByDescending(x => x.Id).ToList();

            var inventory = _inventoryContext.Inventory.Select(x => new { x.Id, x.ProductId, x.UnitPrice, x.InStock, x.Status });
            var discount = _discountContext.Discounts.Where(x => !x.IsRemoved).Select(x => new { x.Id, x.Rate, x.ProductId });

            foreach (var item in products)
            {
                var getInventory = inventory.FirstOrDefault(x => x.ProductId == item.Id);
                if (getInventory != null)
                {
                    double unitPrice = getInventory.UnitPrice;
                    item.UnitPrice = unitPrice;
                    item.InStock = getInventory.InStock;
                    item.Status = getInventory.Status;
                    var getDiscount = discount.FirstOrDefault(x => x.ProductId == item.Id);
                    if (getDiscount != null)
                    {
                        double rate = getDiscount.Rate;
                        item.HasDiscount = rate > 0;
                        item.Discount = rate;
                        var amount = Math.Round((unitPrice / 100) * rate);
                        item.DiscountPrice = (unitPrice - amount);
                    }

                }
            }

            return products;
        }

        public IEnumerable<ProductModel> SearchProduct(string value)
        {
            var getProduct = _shopContext.Products.Select(x => new ProductModel
            {
                Id = x.Id,
                Slug = x.Slug,
                Name = x.Name,
                Picture = "~/fileUploader/" + x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
            });

            getProduct = getProduct.Where(x => x.Name.Contains(value));

            var inventory = _inventoryContext.Inventory.Select(x => new { x.Id, x.ProductId, x.UnitPrice, x.InStock, x.Status });
            var discount = _discountContext.Discounts.Where(x => !x.IsRemoved).Select(x => new { x.Id, x.Rate, x.ProductId });

            var products = getProduct.OrderByDescending(x => x.Id).ToList();
            foreach (var item in products)
            {
                var getInventory = inventory.FirstOrDefault(x => x.ProductId == item.Id);
                if (getInventory != null)
                {
                    double unitPrice = getInventory.UnitPrice;
                    item.UnitPrice = unitPrice;
                    item.InStock = getInventory.InStock;
                    item.Status = getInventory.Status;
                    var getDiscount = discount.FirstOrDefault(x => x.ProductId == item.Id);
                    if (getDiscount != null)
                    {
                        double rate = getDiscount.Rate;
                        item.HasDiscount = rate > 0;
                        item.Discount = rate;
                        var amount = Math.Round((unitPrice / 100) * rate);
                        item.DiscountPrice = (unitPrice - amount);
                    }

                }
            }


            return products;
        }
    }
}
