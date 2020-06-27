using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        public int? CurrentPage { get; set; }
        public PagingModel PagingModel { get; set; }
    }
}
