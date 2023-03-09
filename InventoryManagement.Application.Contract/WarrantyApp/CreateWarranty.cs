using _0_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Application.Contract.WarrantyApp
{
    public class CreateWarranty
    {
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string WarrantyDescription { get; set; }
    }

}
