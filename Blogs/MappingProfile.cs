using AutoMapper;
using Blogs.DAL.Entities;
using Blogs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            RecordToRecordModelMap();
            RecordCreateModelToRecord();
        }

        public void RecordToRecordModelMap()
        {
            CreateMap<Record, RecordModel>()
                .ForMember(to => to.AuthorName, from => from.MapFrom(r => r.Author.UserName))
                .ForMember(to => to.PublishedDate, from => from.MapFrom(r => r.PublishedDate.ToString("D")))
                .ForMember(to => to.ContentPreview, from => from.MapFrom(r => r.Content.Substring(0, 20)));
        }
        public void RecordCreateModelToRecord()
        {
            CreateMap<RecordCreateModel, Record>()
                .ForMember(to => to.PublishedDate, from => from.MapFrom(r => DateTime.Now));
        }
    }
}
