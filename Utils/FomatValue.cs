using ExatoApi.Models;

namespace ExatoApi.Utils
{
    public class FomatValue
    {

        public int Pages { get; set; }
        public IEnumerable<Movie>? Movies { get; set; }

        public FomatValue(IEnumerable<Movie> value, double pages)
        {

            Movies = value;
            Pages = ((int)pages);

        }

    }
}
