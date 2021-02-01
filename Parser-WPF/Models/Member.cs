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
        public Member(string PublicId, string Name, string Email = "", string Web = "")
        {
            this.PublicId = PublicId;
            this.Name = Name;
            this.Email = Email;
            this.Web = Web;
        }

        [Key]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string PublicId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Web { get; set; }
    }
}
