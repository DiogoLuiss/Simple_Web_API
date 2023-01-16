namespace ExatoApi.DTOs
{
    public class ReadProductDto
    {

        public Guid Id { get; set; }
        public string Name { get; set; }

        public DateTime ConsultationTime { get; set; } = DateTime.Now;
    }
}
