using System.ComponentModel.DataAnnotations;

namespace Gamer.Attributes;

public class AllowedExtensionsAttribute(string allowedExtensions):ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {

        var file = value as IFormFile;
        if (file != null) {
            var extension = Path.GetExtension(file.FileName);
            var isAllowed = allowedExtensions.Split(',').Contains(extension, StringComparer.OrdinalIgnoreCase);
            if (!isAllowed) {
                return new ValidationResult($"only {allowedExtensions} are allowed!");
            }
        }
        return ValidationResult.Success;
    }

}
