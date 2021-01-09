using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser_WPF.Models.Base
{
    public class NamedAbbrEntity
    {
        public int Id { get; set; }
        public string Abbreviation { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
