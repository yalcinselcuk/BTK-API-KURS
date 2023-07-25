using AutoMapper;
using StoreApp.DTO.Requests;
using StoreApp.DTO.Responses;
using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Services.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Book, BookResponse>();
            CreateMap<CreateBookRequest, Book>();
        }
    }
}
