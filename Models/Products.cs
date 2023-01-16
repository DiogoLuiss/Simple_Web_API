using Microsoft.OpenApi.Attributes;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DisplayAttribute = Microsoft.OpenApi.Attributes.DisplayAttribute;

namespace ExatoApi.Models
{
    [Table("Products")]
    public class Products
    {

        [Key]
        [Column("Id")]
        [Display("Id")]
        [Required(ErrorMessage = "Campo Id é obrigatório")]
        public Guid Id { get;  set; } = Guid.NewGuid();



        [Column("Name")]
        [Display("Name")]
        [Required(ErrorMessage = "Campo Name é obrigatório")]
        public string Name { get; set; }

    }
}
