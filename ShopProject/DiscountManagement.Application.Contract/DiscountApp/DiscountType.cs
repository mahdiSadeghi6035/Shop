using System.Collections.Generic;
using System.Linq;

namespace DiscountManagement.Application.Contract.DiscountApp
{
    public class DiscountType
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public DiscountType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public static List<DiscountType> ListDiscount()
        {
            return new List<DiscountType>()
            {
               new DiscountType(1,"مشتری"),
               new DiscountType(2,"همکار")
            };
        }
        public static string GetType(int id)
        {
            return ListDiscount().FirstOrDefault(x => x.Id == id)?.Name;
        }
    }
}
