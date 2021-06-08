using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Legends_Razor.Model
{
    public class Legend
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Country { get; set; }
        public string SuperPower { get; set; }
    }
}
