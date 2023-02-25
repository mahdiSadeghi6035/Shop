using _01_ShopQuery.Contract.Category;
using _01_ShopQuery.Contract.GroupingProduct;
using _01_ShopQuery.Contract.Product;
using DiscountManagement.Infrastructure.EfCore;
using InventoryManagement.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.CategoryAgg;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Infrastructure.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_ShopQuery.Query
{
    public class GroupingQuery : IGroupingQuery
    {
        private readonly ShopContext _shopContext;
        private readonly InventoryContext _inventoryContext;
        private readonly DiscountContext _discountContext;
        public GroupingQuery(ShopContext shopContext, InventoryContext ivnetoryContext, DiscountContext discountContext)
        {
            _shopContext = shopContext;
            _inventoryContext = ivnetoryContext;
            _discountContext = discountContext;
        }

        public IEnumerable<GroupingModel> GetGroupingWithCategoryProduct()
        {
            return _shopContext.Groupings.Include(x => x.categories).ThenInclude(x => x.Products).Select(x => new GroupingModel
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
                CategoryModel = MapCategory(x.categories),
            }).OrderByDescending(x => x.Id).ToList();
        }

        private static List<CategoryModel> MapCategory(List<Category> categories)
        {
            return categories.Select(x => new CategoryModel
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
                ProductModel = MapProduct(x.Products)
            }).OrderByDescending(x => x.Id).ToList();
        }

        private static List<ProductModel> MapProduct(List<Product> products)
        {
            return products.Select(x => new ProductModel
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle
            }).OrderByDescending(x => x.Id).ToList();
        }

        public IEnumerable<GroupingModel> GetLatestProduct()
        {
            var query = _shopContext.Groupings
                .Include(x => x.categories)
                .ThenInclude(x => x.Products).Select(x => new GroupingModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Description = x.Description.Substring(0, Math.Min(x.Description.Length, 50)) + "...",
                    CategoryModel = MapCategory(x.categories)
                });
            var product = _shopContext.Products.Select(x => new ProductModel
            {
                Id = x.Id,
                BrandId = x.BrandId,
                CategoryId = x.CategoryId,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                Slug = x.Slug,
                Name = x.Name,
                PictureTitle = x.PictureTitle,
            });

            var grouping = query.OrderByDescending(x => x.Id).ToList();
            var inventory = _inventoryContext.Inventory.Select(x => new { x.Id, x.UnitPrice, x.InStock, x.Status, x.ProductId});
            var discount = _discountContext.Discounts.Where(x => !x.IsRemoved).Select(x => new { x.DiscountType, x.Id, x.IsRemoved, x.Rate, x.ProductId});
            

            foreach (var item in grouping)
            {
                foreach (var itemGrouping in item.CategoryModel)
                {
                    var getProduct = product.Where(x => x.CategoryId == itemGrouping.Id);
                    item.ProductModels = getProduct.OrderByDescending(x => x.Id).Take(4).ToList();
                    foreach (var itemProduct in item.ProductModels)
                    {
                        var getInventory = inventory.FirstOrDefault(x => x.ProductId == itemProduct.Id);
                        if(getInventory != null)
                        {
                            double price = getInventory.UnitPrice;
                            itemProduct.UnitPrice = price;
                            itemProduct.Status = getInventory.Status;
                            itemProduct.InStock = getInventory.InStock;
                            var getDiscount = discount.FirstOrDefault(x => x.ProductId == itemProduct.Id);
                            if(getDiscount != null)
                            {
                                double rate = getDiscount.Rate;
                                itemProduct.HasDiscount = rate > 0;
                                itemProduct.Discount = rate;
                                var discountAmount = Math.Round((price / 100) * rate);
                                itemProduct.DiscountPrice = discountAmount;
                            }
                        }
                        

                    }
                }
            }

            return grouping;
        }
    }
}
