namespace SKL.Models
{
    public partial class Permissao : Entidade
    {
        public int IdPermissao { get; set; }
        public string Descricao { get; set; }
        public byte[] Admin { get; set; }
        public byte[] Gerente { get; set; }
        public byte[] Usuario { get; set; }
    }
}
