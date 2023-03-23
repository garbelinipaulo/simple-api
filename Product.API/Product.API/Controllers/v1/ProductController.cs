using Microsoft.AspNetCore.Mvc;
using Product.Application.Domain.Contracts.Notification;
using Product.Application.Domain.Contracts.Service;
using Product.Application.Domain.Models;

namespace Product.API.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        public ProductController(INotificator notify, IProductService ProductService) : base(notify)
        {
            _productService = ProductService;
        }



        /// <summary>
        /// filter can be used in a specific way ( like category product or something like that, I've just attached to see how it works on repositorie )
        /// </summary>
        /// <param name="page"></param>
        /// <param name="quantity"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet("GetList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetList(int page, int quantity, string? filter)
        {
            return RetornoApi(await _productService.GetList(page, quantity, filter));
        }


        [HttpGet("Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(long ProductId)
        {
            return RetornoApi(await _productService.Get(ProductId));
        }


        [HttpPost("Insert")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Insert(ProductModel obj)
        {
            return RetornoApi(await _productService.Insert(obj));
        }

        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(long ProductId, ProductModel obj)
        {
            return RetornoApi(await _productService.Update(ProductId, obj));
        }

        [HttpDelete("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(long ProductId)
        {
            return RetornoApi(await _productService.Delete(ProductId));
        }
    }
}
