namespace NOR_2022_02_08.Models
{
    public class Pais
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Abreviatura { get; set; }
        public ICollection<Empresa> ?Empresas { get; set; }
    }
}
