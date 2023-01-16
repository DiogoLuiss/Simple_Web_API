using ExatoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExatoApi.Controllers
{

    [ApiController]
    [Route("[controller]")] //aqui é a rota, quando colocamos controller ela pega o nome da class antes da palavra controller

    public class Teste : ControllerBase
    {

        [HttpPost] //Definimos o metodo
        public IActionResult AddProduct([FromBody] Products products) // com [FromBody] pegamos dados do corpo
        {

          
            return CreatedAtAction("teste",products);

        }

    }
}
