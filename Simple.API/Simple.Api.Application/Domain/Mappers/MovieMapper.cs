using AutoMapper;
using Simple.Api.Application.Domain.Dto;
using Simple.Api.Application.Domain.Models;

namespace Simple.Api.Application.Domain.Mappers
{
    public class MovieMapper : Profile
    {
        public MovieMapper()
        {
            CreateMap<MovieDto, MovieModel>() 
                .ReverseMap()
                .ForMember(c => c.Observation, c => c.Ignore());
        }
    }
}
