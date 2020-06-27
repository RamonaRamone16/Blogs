using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.Models
{
    public class RecordFilterModel
    {
        public string Author { get; set; }

        [Display(Name = "Search Key")]
        public string SearchKey { get; set; }

        [Display(Name = "Date From")]
        public DateTime? DateFrom { get; set; }

        [Display(Name = "Date To")]
        public DateTime? DateTo { get; set; }
        public List<RecordModel> Records { get; set; }
    }
}
