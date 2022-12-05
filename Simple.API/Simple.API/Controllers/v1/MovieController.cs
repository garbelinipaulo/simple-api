using Microsoft.AspNetCore.Mvc;
using Simple.Api.Application.Domain.Contracts;
using Simple.Api.Application.Domain.Contracts.Notification;
using Simple.Api.Application.Domain.Dto;

namespace Simple.API.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : BaseController
    {
        private readonly IMovieService _movieService;
        public MovieController(INotificator notify, IMovieService movieService) : base(notify)
        {
            _movieService = movieService;
        }


        [HttpGet("GetMovie")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMovie(int? idMovie)
        { 
            return RetornoApi(await _movieService.GetMovie(idMovie));
        }

        [HttpGet("GetListMovie")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetListMovie(int page, int? quantity)
        {
            return RetornoApi(await _movieService.GetListMovie(page, quantity));
        }


        [HttpPut("InsertMovie")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> InserMovie(MovieDto obj)
        {
            return RetornoApi(await _movieService.InsertMovie(obj));
        }


        [HttpPatch("UpdateMovie")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateMovie(MovieDto obj)
        {
            return RetornoApi(await _movieService.UpdateMovie(obj));
        }


    }
}
