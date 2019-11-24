using System;
using System.Linq;
using AutoMapper;
using Pdgt.BookApi.Contracts;
using Pdgt.BookApi.Services;
using Pdgt.BookApi.Services.Contracts;

namespace Pdgt.BookApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SearchResultItem, BookListItem>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.AuthorNames.FirstOrDefault()))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.PublicationYear, opt => opt.MapFrom(src => src.PublishYears.FirstOrDefault()))
                .ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.Keys.FirstOrDefault()))
                .ForMember(dest => dest.AuthorKey, opt => opt.MapFrom(src => src.AuthorKeys.FirstOrDefault()));

            CreateMap<BookInfo, BookItem>()
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.BookInfoContent.Authors.Select(a => a.Name)))
                .ForMember(dest => dest.NumberOfPages, opt => opt.MapFrom(src => src.BookInfoContent.NumberOfPages))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.BookInfoContent.Title))
                .ForMember(dest => dest.PublishDate, opt => opt.MapFrom(src =>  src.BookInfoContent.PublishDate));


        }
    }
}