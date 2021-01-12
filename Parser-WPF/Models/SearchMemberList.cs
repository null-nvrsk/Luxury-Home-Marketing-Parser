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
        public Country Country { get; set; }
        public State State { get; set; }
        public string MemberLevelId { get; set; }
    }
}
