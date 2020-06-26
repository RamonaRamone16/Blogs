using Blogs.Models;
using System.Collections.Generic;

namespace Blogs.Services.Records
{
    public interface IRecordService
    {
        List<RecordModel> SearchRecords();
        void CreateRecord(RecordCreateModel record, int id);
    }
}
