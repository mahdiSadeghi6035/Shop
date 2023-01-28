using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace _0_Framework.Application
{
    public class FileExtentionLimitationAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly string[] _validationExtention;

        public FileExtentionLimitationAttribute(string[] validationExtention)
        {
            _validationExtention = validationExtention;
        }

        public override bool IsValid(object value)
        {
            var file = value as IFormFile;
            if (file == null)
                return false;
            var files = Path.GetExtension(file.FileName);
            return _validationExtention.Contains(files);
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val-Extention", "true");
            context.Attributes.Add("data-val-ExtentionMessage", ErrorMessage);
        }
    }
}
