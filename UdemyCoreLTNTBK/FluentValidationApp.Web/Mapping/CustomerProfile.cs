using AutoMapper;
using FluentValidationApp.Web.Models;
using FluentValidationApp.Web.DTOs;


namespace FluentValidationApp.Web.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();

        }
    }
}
