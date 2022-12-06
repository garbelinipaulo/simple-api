using AutoMapper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Simple.Api.Application.Domain.Contracts;
using Simple.Api.Application.Domain.Contracts.Notification;
using Simple.Api.Application.Domain.Contracts.Repositories;
using Simple.Api.Application.Domain.Dto;
using Simple.Api.Application.Domain.Models;
using Simple.Api.Application.Service.Base;
using System.Net;

namespace Simple.Api.Application.Service
{
    public class MovieService : BaseService<MovieService>, IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(
            IMovieRepository movieRepository,
            ILogger<MovieService> logger,
            INotificator notify,
            IMapper mapper) : base(logger, notify, mapper)
        {
            _movieRepository = movieRepository;
        }


        public async Task<MovieDto> GetMovie(int? MovieId)
        {
            _logger.LogInformation($"Get Movie by id: {MovieId}");

            var _retorno = await _movieRepository.Get(MovieId.GetValueOrDefault());

            if (_retorno == null)
            {
                _logger.LogInformation($"Result {MovieId} is null");
                _notify.AddNotification("MovieId not found, try send another!", (short)HttpStatusCode.NoContent);
            }

            return _mapper.Map<MovieDto>(_retorno);
        }

        public async Task<List<MovieDto>> GetListMovie(int page, int? quantity)
        {
            _logger.LogInformation($"Get List of Movies in page {page} and amount of {quantity}");

            return _mapper.Map<List<MovieDto>>(await _movieRepository.GetList(page, quantity ?? 10));
        }

        public async Task<int?> InsertMovie(MovieDto obj)
        {
            _logger.LogInformation($"Inserting Movie: {JsonConvert.SerializeObject(obj)} ");

            if (!MovieObjectValidator(obj, false))
                return null;

            return await _movieRepository.Insert(_mapper.Map<MovieModel>(obj));
        }

        public async Task<bool> UpdateMovie(MovieDto obj)
        {
            _logger.LogInformation($"Updating Movie: {JsonConvert.SerializeObject(obj)} ");
             
            if (!MovieObjectValidator(obj, true))
                return false;
              
            return await _movieRepository.Update(_mapper.Map<MovieModel>(obj));
        }

        public bool MovieObjectValidator(MovieDto obj, bool bIsUpdate)
        {
            bool bAllowed = true;

            if(bIsUpdate && obj.MovieId == 0)
            {
                bAllowed = false;
                _notify.AddNotification("MovieId is missing, update not allowed", (short)HttpStatusCode.BadRequest); 
            }

            if (string.IsNullOrEmpty(obj.MovieTitle))
            {
                bAllowed = false;
                _notify.AddNotification("MovieTitle is missing, insert or update not allowed", (short)HttpStatusCode.BadRequest);
            } 

            return bAllowed;
        }
    }
}
