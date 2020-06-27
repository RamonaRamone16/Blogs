using Blogs.Models;

namespace Blogs.Services.Records
{
    public interface IRecordService
    {
        void SearchRecords(RecordCreateModel model, int themeId);
        void CreateRecord(RecordCreateModel record, int themeId);
        void LikeRecord(int recordId);
    }
}
