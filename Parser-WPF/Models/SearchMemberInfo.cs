using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser_WPF.Models
{
    public class SearchMemberInfo
    {
        [Key]
        public int QueueId { get; set; }
        [Required]
        public Member Member { get; set; }
    }
}
