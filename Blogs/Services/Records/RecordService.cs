using AutoMapper;
using Blogs.DAL;
using Blogs.DAL.Entities;
using Blogs.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blogs.Services.Records
{
    public class RecordService : IRecordService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public RecordService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            if (unitOfWorkFactory == null)
                throw new ArgumentNullException(nameof(unitOfWorkFactory));
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public void SearchRecords(RecordCreateModel model, int themeId)
        {
            using (UnitOfWork unitOfWork = _unitOfWorkFactory.Create())
            {
                Theme theme = unitOfWork.Themes.GetWithAuthorsAndRecords(themeId).FirstOrDefault(t => t.Id == themeId);
                model.RecordTheme = Mapper.Map<ThemeModel>(theme);

                int pageSize = 3;
                int currentPage = model.CurrentPage.HasValue ? model.CurrentPage.Value : 1;
                int pagesCount = theme.Records.ToList().Count;

                model.PagingModel = new PagingModel(pagesCount, pageSize, currentPage);
                model.CurrentPage = currentPage;
                theme.Records = theme.Records.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

                model.Records = Mapper.Map<List<RecordModel>>(theme.Records.ToList());
            }
        }

        public void CreateRecord(RecordCreateModel recordCreateModel, int themeId)
        {
            using (UnitOfWork unitOfWork = _unitOfWorkFactory.Create())
            {
                Record record = Mapper.Map<Record>(recordCreateModel);
                record.AuthorId = themeId;
                record.ThemeId = recordCreateModel.RecordTheme.Id;
                unitOfWork.Records.Create(record);
            }
        }

        public void LikeRecord(int recordId)
        {
            using (UnitOfWork unitOfWork = _unitOfWorkFactory.Create())
            {
                Record record = unitOfWork.Records.GetById(recordId);
                record.Likes++;
                unitOfWork.Records.Update(record);
            }
        }
    }
}
