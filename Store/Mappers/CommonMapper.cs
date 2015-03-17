using System;
using AutoMapper;
using DataModul.BaseRepository;
using DataModul.DomainModel;
using Store.Areas.Admin.Models;
using Store.Areas.User.Models;
using Store.Models;

namespace Store.Mappers
{

    public class CommonMapper : IMapper
    {
        public CommonMapper()//(IRepository<Category> categoryRepository)
        {

            Mapper.CreateMap<Category,ViewCategory >();
            Mapper.CreateMap<ViewCategory, Category>();

            Mapper.CreateMap<DataModul.DomainModel.User, ViewUser>();
            Mapper.CreateMap< ViewUser,DataModul.DomainModel.User>();

            Mapper.CreateMap<Product, ViewProduct>();
              //  .ForMember(dest=>dest.Category,
            //    opt=>opt.MapFrom(src=>categoryRepository.GetById(src.Id).Name));
            Mapper.CreateMap<ViewProduct, Product>();
            
            Mapper.CreateMap<Cart,ViewCart>();
            Mapper.CreateMap<ViewCart, Cart>();

        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }
    }

}