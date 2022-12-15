
namespace Dotnet_API_CRUD.Entities
{
    public partial class Produtos
    {
        public int id { get; set; }
        public string descProduto { get; set; } = "";
        public string situacao { get; set; } = "";
        public DateTime dtFabricacao { get; set; }
        public DateTime dtValidade { get; set; }
        public int cdFornecedor { get; set; }
        public string descFornecedor { get; set; } = "";
        public string cnpjFornecedor { get; set; } = "";
    }
}
