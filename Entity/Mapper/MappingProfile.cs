using AutoMapper;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<InstallmentOption, InstallmentOptionDto>().ReverseMap();
            CreateMap<InsuredPerson, InsuredPersonDto>().ReverseMap();
            
            CreateMap<InsuredPersonRelationship, InsuredPersonRelationshipDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<PaymentMethod, PaymentMethodDto>().ReverseMap();

            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
