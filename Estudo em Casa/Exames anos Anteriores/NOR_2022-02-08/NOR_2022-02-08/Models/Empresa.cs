namespace NOR_2022_02_08.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string ?Logotipo { get; set; }
        public int PaisId { get; set; }
        public Pais Pais { get; set; }
    }
}
