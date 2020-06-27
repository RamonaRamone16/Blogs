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

        public List<RecordModel> SearchRecords(RecordFilterModel model)
        {
            using (UnitOfWork unitOfWork = _unitOfWorkFactory.Create())
            {
                IEnumerable<Record> records = unitOfWork.Records.GetAllWithAuthors()
                    .ByAuthor(model.Author)
                    .BySearchKey(model.SearchKey)
                    .ByDateFrom(model.DateFrom)
                    .ByDateTo(model.DateTo);

                int pageSize = 3;
                int currentPage = model.CurrentPage.HasValue ? model.CurrentPage.Value : 1;
                int pagesCount = records.ToList().Count;

                model.PagingModel = new PagingModel(pagesCount, pageSize, currentPage);
                model.CurrentPage = currentPage;

                records = records.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

                return Mapper.Map<List<RecordModel>>(records.ToList());
            }
        }

        public void CreateRecord(RecordCreateModel recordCreateModel, int id)
        {
            using (UnitOfWork unitOfWork = _unitOfWorkFactory.Create())
            {
                Record record = Mapper.Map<Record>(recordCreateModel);
                record.AuthorId = id;
                unitOfWork.Records.Create(record);
            }
        }
    }
}
