using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebsiteLibrary.Models
{
    public class District
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        [Required]
        public string Code { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [Range(1,Int32.MaxValue)]
        public int ProvinceId { get; set; }

        [ForeignKey("ProvinceId")]
        public virtual Province Provinces { get; set; }
    }
}
