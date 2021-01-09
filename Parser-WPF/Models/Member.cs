using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser_WPF.Models
{
    public class Member
    {
        [Key]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string MemberId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
    }
}
