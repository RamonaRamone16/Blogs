using Blogs.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.Services.Records
{
    public static class RecordFilterExtensions
    {
        public static IEnumerable<Record> ByAuthor(this IEnumerable<Record> records, string author)
        {
            if (!string.IsNullOrWhiteSpace(author))
                return records.Where(r => r.Author.UserName.Contains(author));
            return records;
        }
        public static IEnumerable<Record> BySearchKey(this IEnumerable<Record> records, string searchKey)
        {
            if (!string.IsNullOrWhiteSpace(searchKey))
                return records.Where(r => r.Title.Contains(searchKey)|| r.Content.Contains(searchKey));
            return records;
        }

        public static IEnumerable<Record> ByDateFrom(this IEnumerable<Record> records, DateTime? dateFrom)
        {
            if (dateFrom.HasValue)
                return records.Where(r => r.PublishedDate>= dateFrom);
            return records;
        }

        public static IEnumerable<Record> ByDateTo(this IEnumerable<Record> records, DateTime? dateTo)
        {
            if (dateTo.HasValue)
                return records.Where(r => r.PublishedDate <= dateTo);
            return records;
        }
    }
}
