using Blogs.Models;
using System.Collections.Generic;

namespace Blogs.Services.Records
{
    public interface IRecordService
    {
        int LikeRecord(int recordId);
        int DislikeRecord(int recordId);
        List<RecordModel> SearchRecords(int themeId);
        void CreateRecord(RecordModel record, int userId);

        //void SearchRecords(RecordCreateModel model, int themeId);
        //void CreateRecord(RecordCreateModel record, int userId);
    }
}
