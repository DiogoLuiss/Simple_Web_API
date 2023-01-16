using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DisplayAttribute = Microsoft.OpenApi.Attributes.DisplayAttribute;

namespace ExatoApi.DTOs
{
    public class CreateProductDto
    {

        [Column("Name")]
        [Display("Name")]
        [Required(ErrorMessage = "Campo Name é obrigatório")]
        public string Name { get; set; }

    }
}
