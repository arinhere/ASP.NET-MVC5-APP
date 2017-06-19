using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.Dto;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Customers, CustomersDto>();
            CreateMap<CustomersDto, Customers>().ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<Membership, MembershipTypDto>();
            
            CreateMap<Movies, MoviesDto>();
            CreateMap<MoviesDto, Movies>().ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<MovieGenre, MovieGenreDto>();
        }
    }
}