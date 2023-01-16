using System.ComponentModel.DataAnnotations;

namespace ExatoApi.Models;

public class Movie
{
    [Required(ErrorMessage = "Campo Id é obrigatório")]
    public Guid Id  {get; private set; }  = Guid.NewGuid();

    [Required(ErrorMessage = "Campo Titulo é obrigatório")]
    [StringLength(50, ErrorMessage = "Campo Titulo deve conter no maximo 50 digitos")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "Campo genero é obrigatório")]
    [StringLength(50, ErrorMessage = "Campo genero deve conter no maximo 50 digitos")]
    public string? Genre { get; set; }



    [Required(ErrorMessage = "Campo Duração do filme é obrigatório")]
    [Range(70,600, ErrorMessage = "Campo Duração do filme deve conter valores entre 70 e 600")]
    [RegularExpression("([0-9]+)", ErrorMessage = "Por favor, insira um número válido")]
    public string? FilmeLenght { get; set; }


   
 

}
