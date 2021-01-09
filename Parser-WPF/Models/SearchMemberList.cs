using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser_WPF.Models
{
    public class SearchMemberList
    {
        [Key]
        public int QueueId { get; set; }
        [Required]
        //public int CountryId { get; set; }
        public string CountryAbbreviation { get; set; }
        //public int StateId { get; set; }
        public string StateAbbreviation { get; set; }
        public string MemberLevelId { get; set; }
    }
}
