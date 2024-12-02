using System.ComponentModel.DataAnnotations;

namespace Gamer.Attributes
{
    public class MaxFileSizeAttribute(int maxFileSize):ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if(file is not null)
            {
                if(file.Length> maxFileSize)
                {
                    return new ValidationResult(ErrorMessage=$"maximum allowed size is {maxFileSize}bytes");
                }
            }
            return  ValidationResult.Success;
        }
    }
}
