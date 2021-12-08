using System.ComponentModel.DataAnnotations;

namespace PlatformService.Models
{
    public class Platform
    {
        public Platform(string name, string publisher, string cost)
        {
            Name = name;
            Publisher = publisher;
            Cost = cost;
        }

        [Key]
        [Required]
        public int Id { get; private set; }
        [Required]
        public string Name { get; private set; }
        [Required]
        public string Publisher { get; private set; }
        [Required]
        public string Cost { get; private set; }
    }
}