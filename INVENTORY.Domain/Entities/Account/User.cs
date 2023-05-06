using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INVENTORY.Domain.Entities.Settings;

namespace INVENTORY.Domain.Entities.Account
{
    [Table("Users")]
    public class User : BaseEntity
    {
        [Required, MaxLength(50)]
        public string? UserId { get; set; }
        [Required, MaxLength(100)]
        public string? Password { get; set; }
        [MaxLength(100)]
        public string? FirstName { get; set; }
        [MaxLength(100)]
        public string? LastName { get; set; }
        [MaxLength(100)]
        public string? Email { get; set; }
        public string? Roll { get; set; }

        public List<Region>? Regions { get; set; }
        public List<Territory>? Territories { get; set; }
        public List<Area>? Areas { get; set; }
        public List<KamAreaMapping>? KamAreaMappings { get; set; }
        public List<Customer>? Customers { get; set; }

    }
}
