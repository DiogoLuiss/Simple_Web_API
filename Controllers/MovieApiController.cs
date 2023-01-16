using ExatoApi.Models;
using ExatoApi.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace ExatoApi.Controllers;




[ApiController]
[Route("[controller]")] //aqui é a rota, quando colocamos controller ela pega o nome da class antes da palavra controller



public class MovieApiController: ControllerBase
{
 

    private static List<Movie> movies = new List<Movie>();

    /// text  
    [HttpPost] //Definimos o metodo
    public IActionResult AddMovie([FromBody] Movie movie) // com [FromBody] pegamos dados do corpo
    {

        movies.Add(movie);
        return CreatedAtAction(nameof(GetMovieId), new { id = movie.Id }, movie);
     
    }




    [HttpGet] //Definimos o metodo

    public FomatValue GetAllMovie([FromQuery] int page, int size) // com [FromBody] pegamos dados do corpo
    {
        int  pages = movies.Count / size ;
        FomatValue Value = new(movies.Skip(page * size).Take(size), pages);

        return Value;
    }

    [HttpGet("{id}")] //Forma de avisar a requisição que sera uma busca com id

    public IActionResult GetMovieId(Guid id)
    {
        var movie = movies.FirstOrDefault(movies => movies.Id == id);
        if (movie == null)
        {
            return NotFound();
        }

        return Ok(movies.FirstOrDefault(movies => movies.Id == id));
    }

}
