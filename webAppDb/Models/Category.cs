using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webAppDb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("DisplayName")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage ="Display Order must be greater than 0")]
        public int DisplayOrder { get; set; }
    }
}
