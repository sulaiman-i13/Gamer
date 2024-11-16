using System.ComponentModel.DataAnnotations;

namespace Gamer.Models
{
    public class BaseEntity
    {
        public int Id { get; set; } = default!;
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;
    }
}
