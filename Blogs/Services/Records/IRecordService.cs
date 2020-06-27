using Blogs.Models;
using System.Collections.Generic;

namespace Blogs.Services.Records
{
    public interface IRecordService
    {
        void SearchRecords(RecordCreateModel model, int themeId);
        void CreateRecord(RecordCreateModel record, int id);
    }
}
