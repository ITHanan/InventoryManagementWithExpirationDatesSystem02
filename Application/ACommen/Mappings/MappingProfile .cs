using ApplicationLayer.ACommen.DTOs;
using AutoMapper;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.ACommen.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Stock, StockDTO>().ReverseMap();
            CreateMap<Item, ItemDto>().ReverseMap(); ;
            CreateMap<Supplier, SupplierDto>().ReverseMap(); ;
        }
    }
}