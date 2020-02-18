using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebsiteLibrary.Models
{
    public class Province
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        [Required]
        public string Code { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        public ICollection<District> Districts { get; set; }
    }
}
