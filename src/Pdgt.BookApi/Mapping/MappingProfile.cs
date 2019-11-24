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
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.AuthorName))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.ShortDescription, opt => opt.MapFrom(src => src.AuthorName))
                .ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.Key));

            CreateMap<BookInfo, BookItem>()
                .ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.Identifiers.Select(id => id.Isbn10.Values.FirstOrDefault())))
                .ForMember(dest => dest.PublishDate, opt => opt.MapFrom(src =>  DateTime.Parse(src.PublishDate)));


        }
    }
}