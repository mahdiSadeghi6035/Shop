using _0_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Application.Contract.InventoryApp
{
    public class OperationInventoryModel
    {
        public long InventoryId { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = ValidationMessage.RequiredMessage)]
        public long Count { get; set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string Description { get; set; }
    }
}
