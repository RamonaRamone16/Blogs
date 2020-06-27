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
            RecordCreateModelToRecordMap();
            ThemeToThemeModelMap();
            ThemeCreateModelToThemeMap();
        }

        public void RecordToRecordModelMap()
        {
            CreateMap<Record, RecordModel>()
                .ForMember(to => to.AuthorName, from => from.MapFrom(r => r.Author.UserName))
                .ForMember(to => to.PublishedDate, from => from.MapFrom(r => r.PublishedDate.ToString("D")))
                .ForMember(to => to.Content, from => from.MapFrom(r => r.Content))
                .ForMember(to => to.AuthorAnswersCount, from => from.MapFrom(r => r.Author.Records.Count));
        }
        public void RecordCreateModelToRecordMap()
        {
            CreateMap<RecordCreateModel, Record>()
                .ForMember(to => to.PublishedDate, from => from.MapFrom(r => DateTime.Now));
        }

        public void ThemeToThemeModelMap()
        {
            CreateMap<Theme, ThemeModel>()
                .ForMember(to => to.AuthorName, from => from.MapFrom(t => t.Author.UserName))
                .ForMember(to => to.RecordsCount, from => from.MapFrom(t => t.Records.Count));
        }

        public void ThemeCreateModelToThemeMap()
        {
            CreateMap<ThemeCreateModel, Theme>()
                .ForMember(to => to.PublishedDate, from => from.MapFrom(r => DateTime.Now));
        }
    }
}
