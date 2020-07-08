using Blogs.Models;
using System.Collections.Generic;

namespace Blogs.Services.Records
{
    public interface IRecordService
    {
        //void SearchRecords(RecordCreateModel model, int themeId);
        //void CreateRecord(RecordCreateModel record, int userId);
        int LikeRecord(int recordId);
        List<RecordModel> SearchRecords(int themeId);
        void CreateRecord(RecordModel record, int userId);
    }
}
