using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExatoApi.Models;
using ExatoApi.DTOs;
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.JsonPatch;

namespace ExatoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProductsController : Controller
    {
        private readonly Context _context;
        private IMapper _mapper;
        public ProductsController(Context context, IMapper mapper)
        {
             _context = context;
            _mapper = mapper;

        }



        /// <summary>
        /// Lista os produtos do banco de dados
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a busca seja feita com sucesso</response>


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> FindProdct()
        {
            try
            {

                var Products = await _context.Products.Skip(0).Take(100).ToListAsync();
                if (Products != null)
                {
                    return Ok(_mapper.Map<List<ReadProductDto>>(Products));
                }

                return NoContent();


            }
            catch (Exception Error)
            {
                return Problem(Error.Message);
       
            }
     
        }


        /// <summary>
        /// Busca um produto ao banco de dados
        /// </summary>
        /// <param name="id">Campo necessario para indentificação do produto</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a busca seja feita com sucesso</response>


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> FindProdctForId([Bind("id")] Guid id)
        {

            var product = await _context.Products.FirstOrDefaultAsync(product => product.Id == id);
            if (product == null)
                return NotFound();

          var teste =  _mapper.Map<ReadProductDto>(product);


            return Ok(teste);

        }


        /// <summary>
        /// Adiciona um produto ao banco de dados
        /// </summary>
        /// <param name="productDto">Objeto com os campos necessários para criação de um produto</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct([Bind("Name")][FromBody] CreateProductDto productDto )
        {
            if (ModelState.IsValid)
            {
                Products product = _mapper.Map<Products>(productDto);
                _context.Add(product);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(FindProdctForId), new { id = product.Id}, product);
                
            }
            else
            {
                return BadRequest();
            }
 
        }

        /// <summary>
        /// Atualiza um produto do banco de dados
        /// </summary>
        /// <param name="productDto">Objeto com os campos necessários para criação de um produto</param>
        /// <param name="id">Campo necessario para indentificação do produto</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso inserção seja feita com sucesso</response>

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public async Task<IActionResult> UpdateMovie([Bind("id,Name")] Guid id, UpdateProductDto productDto)
        {
            var product = await _context.Products.FirstOrDefaultAsync(product => product.Id == id);
            if (product == null)
             return BadRequest();

           _mapper.Map(productDto, product);

            _context.SaveChanges();
            return NoContent();

        }


        /// <summary>
        /// Atualiza um produto de forma parcial do banco de dados
        /// </summary>
        /// <param name="patch">Json com os campos necessários para atualização de um produto</param>
        /// <param name="id">Campo necessario para indentificação do produto</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso inserção seja feita com sucesso</response>


        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateProduct( Guid id, JsonPatchDocument<UpdateProductDto> patch)
        {
            var product = await _context.Products.FirstOrDefaultAsync(product => product.Id == id);
            if (product == null)
                return BadRequest();

            var ProductForUpdate = _mapper.Map<UpdateProductDto>(product);//Transforma UpdateProductDto em product

            patch.ApplyTo(ProductForUpdate, ModelState);

            if (!TryValidateModel(ProductForUpdate))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(ProductForUpdate,product);

            _context.SaveChanges();
            return NoContent();

        }


        /// <summary>
        /// Deleta um produto do banco de dados
        /// </summary>
        /// <param name="id">Campo necessario para indentificação do produto</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a requisição seja feita com sucesso</response>


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(product => product.Id == id);
            if (product == null)
                return NotFound();

            _context.Remove(product);
            _context.SaveChanges();
            return NoContent();

        }
    }
}
